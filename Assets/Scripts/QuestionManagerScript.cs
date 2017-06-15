using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionManagerScript : MonoBehaviour {

	public List<Sprite> listQuestions; 
	public List<int> listAnswers; 

	public List<Sprite> listQuestionsAdd; 
	public List<int> listAnswersAdd; 

	public List<Sprite> listQuestionsMul; 
	public List<int> listAnswersMul;

	public List<Sprite> listQuestionsDiv; 
	public List<int> listAnswersDiv;

	///Start this is for Bonus Question
	public List<Sprite> listBonusQuestionsAddSub; 
	public List<Sprite> listBonusQuestionsMul; 
	public List<Sprite> listBonusQuestionsDiv; 
	///End this is for Bonus Question

	public int tempRandNum;
	public Sprite tempQuestion;
	public int tempAnswer;

	public ScoreManagerScript SM_Script;

	//Start Question
	public Sprite Q1;
	public Sprite Q2;
	public Sprite Q3;
	public Sprite Q4;
	public Sprite Q5;
	public Sprite Q6;
	public Sprite Q7;
	public Sprite Q8;
	public Sprite Q9;
	public Sprite Q10;
	public Sprite Q11;
	public Sprite Q12;
	public Sprite Q13;
	public Sprite Q14;
	public Sprite Q15;
	public Sprite Q16;
	public Sprite Q17;
	public Sprite Q18;
	public Sprite Q19;
	public Sprite Q20;
	public Sprite Q21;
	public Sprite Q22;
	public Sprite Q23;
	public Sprite Q24;
	public Sprite Q25;
	public Sprite Q26;
	public Sprite Q27;
	public Sprite Q28;
	public Sprite Q29;
	public Sprite Q30;
	public Sprite Q31;
	public Sprite Q32;
	public Sprite Q33;
	public Sprite Q34;
	public Sprite Q35;
	public Sprite Q36;
	public Sprite Q37;
	public Sprite Q38;
	public Sprite Q39;
	public Sprite Q40;
	public Sprite Q41;
	public Sprite Q42;
	public Sprite Q43;
	public Sprite Q44;
	public Sprite Q45;
	public Sprite Q46;
	public Sprite Q47;
	public Sprite Q48;
	public Sprite Q49;
	public Sprite Q50;
	public Sprite Q51;
	public Sprite Q52;
	public Sprite Q53;
	public Sprite Q54;
	public Sprite Q55;
	public Sprite Q56;
	public Sprite Q57;
	public Sprite Q58;
	public Sprite Q59;
	public Sprite Q60;
	public Sprite Q61;
	public Sprite Q62;
	public Sprite Q63;
	public Sprite Q64;
	public Sprite Q65;
	public Sprite Q66;
	public Sprite Q67;
	public Sprite Q68;
	public Sprite Q69;
	public Sprite Q70;
	public Sprite Q71;
	public Sprite Q72;
	public Sprite Q73;
	public Sprite Q74;
	public Sprite Q75;
	public Sprite Q76;
	public Sprite Q77;
	public Sprite Q78;
	public Sprite Q79;
	public Sprite Q80;
	//End Question


	//Start Bonus Question
	public Sprite BQ1;
	public Sprite BQ2;
	public Sprite BQ3;
	public Sprite BQ4;
	public Sprite BQ5;
	public Sprite BQ6;
	public Sprite BQ7;
	public Sprite BQ8;
	public Sprite BQ9;
	public Sprite BQ10;
	public Sprite BQ11;
	public Sprite BQ12;
	public Sprite BQ13;
	public Sprite BQ14;
	public Sprite BQ15;
	public Sprite BQ16;
	public Sprite BQ17;
	public Sprite BQ18;
	public Sprite BQ19;
	public Sprite BQ20;
	public Sprite BQ21;
	public Sprite BQ22;
	public Sprite BQ23;
	public Sprite BQ24;
	public Sprite BQ25;
	public Sprite BQ26;
	public Sprite BQ27;
	public Sprite BQ28;
	public Sprite BQ29;
	public Sprite BQ30;
	//End Bonus Question

	// Use this for initialization
	void Start ()
	{

		listQuestions = new List<Sprite>();


		//Start questions for Addition
		listQuestionsAdd = new List<Sprite>();
		listQuestionsAdd.Add(Q1);
		listQuestionsAdd.Add(Q2);
		listQuestionsAdd.Add(Q3);
		listQuestionsAdd.Add(Q4);
		listQuestionsAdd.Add(Q5);
		listQuestionsAdd.Add(Q6);
		listQuestionsAdd.Add(Q7);
		listQuestionsAdd.Add(Q8);
		listQuestionsAdd.Add(Q9);
		listQuestionsAdd.Add(Q10);
		listQuestionsAdd.Add(Q11);
		listQuestionsAdd.Add(Q12);
		listQuestionsAdd.Add(Q13);
		listQuestionsAdd.Add(Q14);
		listQuestionsAdd.Add(Q15);
		listQuestionsAdd.Add(Q16);
		listQuestionsAdd.Add(Q17);
		listQuestionsAdd.Add(Q18);
		listQuestionsAdd.Add(Q19);
		listQuestionsAdd.Add(Q20);
		//END questions for Addition
		//Start questions for Subtraction
		listQuestionsAdd.Add(Q21);
		listQuestionsAdd.Add(Q22);
		listQuestionsAdd.Add(Q23);
		listQuestionsAdd.Add(Q24);
		listQuestionsAdd.Add(Q25);
		listQuestionsAdd.Add(Q26);
		listQuestionsAdd.Add(Q27);
		listQuestionsAdd.Add(Q28);
		listQuestionsAdd.Add(Q29);
		listQuestionsAdd.Add(Q30);
		listQuestionsAdd.Add(Q31);
		listQuestionsAdd.Add(Q32);
		listQuestionsAdd.Add(Q33);
		listQuestionsAdd.Add(Q34);
		listQuestionsAdd.Add(Q35);
		listQuestionsAdd.Add(Q36);
		listQuestionsAdd.Add(Q37);
		listQuestionsAdd.Add(Q38);
		listQuestionsAdd.Add(Q39);
		listQuestionsAdd.Add(Q40);
		//END questions for Subtraction
		//Start questions for Multiplication
		listQuestionsMul = new List<Sprite> ();
		listQuestionsMul.Add(Q41);
		listQuestionsMul.Add(Q42);
		listQuestionsMul.Add(Q43);
		listQuestionsMul.Add(Q44);
		listQuestionsMul.Add(Q45);
		listQuestionsMul.Add(Q46);
		listQuestionsMul.Add(Q47);
		listQuestionsMul.Add(Q48);
		listQuestionsMul.Add(Q49);
		listQuestionsMul.Add(Q50);
		listQuestionsMul.Add(Q51);
		listQuestionsMul.Add(Q52);
		listQuestionsMul.Add(Q53);
		listQuestionsMul.Add(Q54);
		listQuestionsMul.Add(Q55);
		listQuestionsMul.Add(Q56);
		listQuestionsMul.Add(Q57);
		listQuestionsMul.Add(Q58);
		listQuestionsMul.Add(Q59);
		listQuestionsMul.Add(Q60);
		//END questions for Multiplication
		//Start questions for Division
		listQuestionsDiv = new List<Sprite> ();
		listQuestionsDiv.Add(Q61);
		listQuestionsDiv.Add(Q62);
		listQuestionsDiv.Add(Q63);
		listQuestionsDiv.Add(Q64);
		listQuestionsDiv.Add(Q65);
		listQuestionsDiv.Add(Q66);
		listQuestionsDiv.Add(Q67);
		listQuestionsDiv.Add(Q68);
		listQuestionsDiv.Add(Q69);
		listQuestionsDiv.Add(Q70);
		listQuestionsDiv.Add(Q71);
		listQuestionsDiv.Add(Q72);
		listQuestionsDiv.Add(Q73);
		listQuestionsDiv.Add(Q74);
		listQuestionsDiv.Add(Q75);
		listQuestionsDiv.Add(Q76);
		listQuestionsDiv.Add(Q77);
		listQuestionsDiv.Add(Q78);
		listQuestionsDiv.Add(Q79);
		listQuestionsDiv.Add(Q80);
		//END questions for Division

		if(SVM_Script.gameDifficulty=="easy"){
			for(int x=0; x<listQuestionsAdd.Count; x++)
			{
				listQuestions.Add(listQuestionsAdd[x]);
			}

		}

		else if(SVM_Script.gameDifficulty=="advance")
		{
			for(int x=0; x<listQuestionsMul.Count; x++)
			{
				listQuestions.Add(listQuestionsMul[x]);
			}
		}

		else if(SVM_Script.gameDifficulty=="expert")
		{
			for(int x=0; x<listQuestionsDiv.Count; x++)
			{
				listQuestions.Add(listQuestionsDiv[x]);
			}
		}


		listBonusQuestionsAddSub = new List<Sprite> ();
		listBonusQuestionsAddSub.Add(BQ1);
		listBonusQuestionsAddSub.Add(BQ2);
		listBonusQuestionsAddSub.Add(BQ3);
		listBonusQuestionsAddSub.Add(BQ4);
		listBonusQuestionsAddSub.Add(BQ5);
		listBonusQuestionsAddSub.Add(BQ6);
		listBonusQuestionsAddSub.Add(BQ7);
		listBonusQuestionsAddSub.Add(BQ8);
		listBonusQuestionsAddSub.Add(BQ9);
		listBonusQuestionsAddSub.Add(BQ10);

		listBonusQuestionsMul = new List<Sprite> ();
		listBonusQuestionsMul.Add(BQ11);
		listBonusQuestionsMul.Add(BQ12);
		listBonusQuestionsMul.Add(BQ13);
		listBonusQuestionsMul.Add(BQ14);
		listBonusQuestionsMul.Add(BQ15);
		listBonusQuestionsMul.Add(BQ16);
		listBonusQuestionsMul.Add(BQ17);
		listBonusQuestionsMul.Add(BQ18);
		listBonusQuestionsMul.Add(BQ19);
		listBonusQuestionsMul.Add(BQ20);

		listBonusQuestionsDiv = new List<Sprite> ();
		listBonusQuestionsDiv.Add(BQ21);
		listBonusQuestionsDiv.Add(BQ22);
		listBonusQuestionsDiv.Add(BQ23);
		listBonusQuestionsDiv.Add(BQ24);
		listBonusQuestionsDiv.Add(BQ25);
		listBonusQuestionsDiv.Add(BQ26);
		listBonusQuestionsDiv.Add(BQ27);
		listBonusQuestionsDiv.Add(BQ28);
		listBonusQuestionsDiv.Add(BQ29);
		listBonusQuestionsDiv.Add(BQ30);




		//-------------------This is the Answers----------------------//

		listAnswersMul = new List<int>();
		//Start of Answer for Multiplication
		listAnswersMul.Add(2);
		listAnswersMul.Add(5);
		listAnswersMul.Add(3);
		listAnswersMul.Add(7);
		listAnswersMul.Add(6);

		listAnswersMul.Add(2);
		listAnswersMul.Add(8);
		listAnswersMul.Add(9);
		listAnswersMul.Add(4);
		listAnswersMul.Add(3);

		listAnswersMul.Add(3);
		listAnswersMul.Add(9);
		listAnswersMul.Add(9);
		listAnswersMul.Add(2);
		listAnswersMul.Add(6);

		listAnswersMul.Add(7);
		listAnswersMul.Add(8);
		listAnswersMul.Add(6);
		listAnswersMul.Add(9);
		listAnswersMul.Add(7);


		listAnswersDiv = new List<int> ();
		//Start of Answer for Division
		listAnswersDiv.Add(8);
		listAnswersDiv.Add(3);
		listAnswersDiv.Add(5);
		listAnswersDiv.Add(6);
		listAnswersDiv.Add(7);

		listAnswersDiv.Add(9);
		listAnswersDiv.Add(5);
		listAnswersDiv.Add(4);
		listAnswersDiv.Add(9);
		listAnswersDiv.Add(9);

		listAnswersDiv.Add(8);
		listAnswersDiv.Add(2);
		listAnswersDiv.Add(3);
		listAnswersDiv.Add(4);
		listAnswersDiv.Add(5);

		listAnswersDiv.Add(8);
		listAnswersDiv.Add(6);
		listAnswersDiv.Add(9);
		listAnswersDiv.Add(3);
		listAnswersDiv.Add(4);

		listAnswersAdd = new List<int> ();
		//Start of answer for Addition
		listAnswersAdd.Add(5);
		listAnswersAdd.Add(4);
		listAnswersAdd.Add(9);
		listAnswersAdd.Add(9);
		listAnswersAdd.Add(5);
				   
		listAnswersAdd.Add(8);
		listAnswersAdd.Add(4);
		listAnswersAdd.Add(6);
		listAnswersAdd.Add(8);
		listAnswersAdd.Add(9);
				   
		listAnswersAdd.Add(2);
		listAnswersAdd.Add(4);
		listAnswersAdd.Add(3);
		listAnswersAdd.Add(1);
		listAnswersAdd.Add(6);
				   
		listAnswersAdd.Add(1);
		listAnswersAdd.Add(2);
		listAnswersAdd.Add(2);
		listAnswersAdd.Add(4);
		listAnswersAdd.Add(6);
		//END of answer for Addition
				   
		//Start of answer for Subtration
		listAnswersAdd.Add(1);
		listAnswersAdd.Add(5);
		listAnswersAdd.Add(6);
		listAnswersAdd.Add(8);
		listAnswersAdd.Add(5);
				   
		listAnswersAdd.Add(5);
		listAnswersAdd.Add(8);
		listAnswersAdd.Add(9);
		listAnswersAdd.Add(9);
		listAnswersAdd.Add(9);
				   
		listAnswersAdd.Add(2);
		listAnswersAdd.Add(9);
		listAnswersAdd.Add(8);
		listAnswersAdd.Add(6);
		listAnswersAdd.Add(4);
				   
		listAnswersAdd.Add(9);
		listAnswersAdd.Add(4);
		listAnswersAdd.Add(7);
		listAnswersAdd.Add(7);
		listAnswersAdd.Add(1);
		//END of answer for Subtration

		listAnswers = new List<int>();	//List of questions new
		if(SVM_Script.gameDifficulty=="easy")
		{
			for(int x=0; x<listAnswersAdd.Count; x++)
			{
				listAnswers.Add(listAnswersAdd[x]);
			}
		}

		else if(SVM_Script.gameDifficulty=="advance")
		{
			for(int x=0; x<listAnswersMul.Count; x++)
			{
				listAnswers.Add(listAnswersMul[x]);
			}
		}

		else if(SVM_Script.gameDifficulty=="expert")
		{
			for(int x=0; x<listAnswersDiv.Count; x++)
			{
				listAnswers.Add(listAnswersDiv[x]);
			}
		}
	}

	public Sprite GetQuestion()
	{
		tempRandNum = Random.Range(0,listQuestions.Count);
		
		//Debug.Log (tempRandNum);
		tempQuestion = listQuestions[tempRandNum];
		tempAnswer = listAnswers[tempRandNum];
		SM_Script.currentAnswerInSM = tempAnswer;
		listQuestions.RemoveAt(tempRandNum);
		listAnswers.RemoveAt(tempRandNum);

		return tempQuestion;
	}




	public void SwitchToBonusRound()
	{
		listQuestions.Clear();
		listAnswers.Clear();

		///Start this is to populate questions
		for(int x=0; x<listBonusQuestionsAddSub.Count; x++)
		{
			listQuestions.Add(listBonusQuestionsAddSub[x]);
			if (x < 5) {
				listAnswers.Add (1);
			} else {
				listAnswers.Add (2);
			}
		}
		if(SVM_Script.gameDifficulty=="advance" || SVM_Script.gameDifficulty=="expert")
		{
			for(int x=0; x<listBonusQuestionsMul.Count; x++)
			{
				listQuestions.Add(listBonusQuestionsMul[x]);
				listAnswers.Add (3);

			}
		}
		if(SVM_Script.gameDifficulty=="expert")
		{
			for(int x=0; x<listBonusQuestionsDiv.Count; x++)
			{
				listQuestions.Add(listBonusQuestionsDiv[x]);
				listAnswers.Add (4);
			}
		}
	}
}