using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBlockGenerator : MonoBehaviour {

	//Object to generate randomly
	public LevelBlock levelBlock;
	public LevelBlock currentLevelBlock;
	public LevelBlock lastLevelBlock; //Last block to was appended
	public PipeMovement blockPipe;
	public float generationBlockTime;
	
	// Start is called before the first frame update
    void Start() {
        AddNewBlock();

		InvokeRepeating("GenerateNewBlockPipe", 0, generationBlockTime);
    }

    // Update is called once per frame
    void Update() {
        //Get the position of the camera
		float xcam = Camera.main.transform.position.x;
		//Position of X on the exitPoint attribute
		float xold = lastLevelBlock.exitPoint.position.x;

		if (xcam > xold + lastLevelBlock.width/2) {
			RemoveOldBlock();
		}
    }

    public void AddNewBlock() {
    	// Generate a new block and append like a child of LevelBlockGenerator
    	LevelBlock block = (LevelBlock) Instantiate(levelBlock);
    	block.transform.SetParent(this.transform, false);

    	//Position of block at the end of the last level block
    	Vector3 blockPosition = new Vector3 (
			lastLevelBlock.exitPoint.position.x + block.width/2,
			lastLevelBlock.exitPoint.position.y,
			lastLevelBlock.exitPoint.position.z);
    	
		block.transform.position = blockPosition;

		currentLevelBlock = block;
    }

    public void RemoveOldBlock() {
		
		lastLevelBlock.transform.position = new Vector3( 
			lastLevelBlock.transform.position.x + 2 * lastLevelBlock.width,
			lastLevelBlock.transform.position.y,
			lastLevelBlock.transform.position.z);

		LevelBlock temp = lastLevelBlock;
		lastLevelBlock = currentLevelBlock;
		currentLevelBlock = temp;
	}

	public void GenerateNewBlockPipe() {

		float distanceToGenerate = levelBlock.width/2;
		//Random distance of pipe
		float randomY = Random.Range(2, 10);
		//Randon velocity of pipes
		float randomV = Random.Range(4, 10);

		PipeMovement pipeBlock = (PipeMovement) Instantiate(blockPipe);
		Vector3 pipePosition = new Vector3 (Camera.main.transform.position.x + distanceToGenerate, randomY, 0);
		pipeBlock.speed = randomV;
		pipeBlock.transform.position = pipePosition;
	}
}
