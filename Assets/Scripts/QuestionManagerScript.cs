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


		listQuestionsAdd = new List<Sprite>
		{
			//Start questions for Addition
			Q1,
			Q2,
			Q3,
			Q4,
			Q5,
			Q6,
			Q7,
			Q8,
			Q9,
			Q10,
			Q11,
			Q12,
			Q13,
			Q14,
			Q15,
			Q16,
			Q17,
			Q18,
			Q19,
			Q20,
			//END questions for Addition
			//Start questions for Subtraction
			Q21,
			Q22,
			Q23,
			Q24,
			Q25,
			Q26,
			Q27,
			Q28,
			Q29,
			Q30,
			Q31,
			Q32,
			Q33,
			Q34,
			Q35,
			Q36,
			Q37,
			Q38,
			Q39,
			Q40
			//END questions for Subtraction
		};
		listQuestionsMul = new List<Sprite>
		{
			//Start questions for Multiplication
			Q41,
			Q42,
			Q43,
			Q44,
			Q45,
			Q46,
			Q47,
			Q48,
			Q49,
			Q50,
			Q51,
			Q52,
			Q53,
			Q54,
			Q55,
			Q56,
			Q57,
			Q58,
			Q59,
			Q60
			//END questions for Multiplication
		};
		listQuestionsDiv = new List<Sprite>
		{
			//Start questions for Division
			Q61,
			Q62,
			Q63,
			Q64,
			Q65,
			Q66,
			Q67,
			Q68,
			Q69,
			Q70,
			Q71,
			Q72,
			Q73,
			Q74,
			Q75,
			Q76,
			Q77,
			Q78,
			Q79,
			Q80
			//END questions for Division
		};

		listBonusQuestionsAddSub = new List<Sprite>
		{
			BQ1,
			BQ2,
			BQ3,
			BQ4,
			BQ5,
			BQ6,
			BQ7,
			BQ8,
			BQ9,
			BQ10
		};
		listBonusQuestionsMul = new List<Sprite>
		{
			BQ11,
			BQ12,
			BQ13,
			BQ14,
			BQ15,
			BQ16,
			BQ17,
			BQ18,
			BQ19,
			BQ20
		};
		listBonusQuestionsDiv = new List<Sprite>
		{
			BQ21,
			BQ22,
			BQ23,
			BQ24,
			BQ25,
			BQ26,
			BQ27,
			BQ28,
			BQ29,
			BQ30
		};




		//-------------------This is the Answers----------------------//

		listAnswersMul = new List<int>
		{
			//Start of Answer for Multiplication
			2,
			5,
			3,
			7,
			6,

			2,
			8,
			9,
			4,
			3,

			3,
			9,
			9,
			2,
			6,

			7,
			8,
			6,
			9,
			7
			//End of answers for Multiplication
		};
		listAnswersDiv = new List<int>
		{
			//Start of Answer for Division
			8,
			3,
			5,
			6,
			7,

			9,
			5,
			4,
			9,
			9,

			8,
			2,
			3,
			4,
			5,

			8,
			6,
			9,
			3,
			4
			//End of answers for Division
		};
		listAnswersAdd = new List<int>
		{
			//Start of answers for Addition
			5,
			4,
			9,
			9,
			5,

			8,
			4,
			6,
			8,
			9,

			2,
			4,
			3,
			1,
			6,

			1,
			2,
			2,
			4,
			6,
			//END of answers for Addition

			//Start of answers for Subtration
			1,
			5,
			6,
			8,
			5,

			5,
			8,
			9,
			9,
			9,

			2,
			9,
			8,
			6,
			4,

			9,
			4,
			7,
			7,
			1
			//END of answers for Subtration
		};

		listAnswers = new List<int>();  //List of questions new
		RepopulateQuestions();
	}

	void RepopulateQuestions()
	{
		if (SVM_Script.gameDifficulty=="easy"){
			for(int x=0; x<listQuestionsAdd.Count; x++)
			{
				listQuestions.Add(listQuestionsAdd[x]);
			}
			for(int x=0; x<listAnswersAdd.Count; x++)
			{
				listAnswers.Add(listAnswersAdd[x]);
			}
		}

		else if(SVM_Script.gameDifficulty=="advance")
		{
			for(int x=0; x<listQuestionsMul.Count; x++)
			{
				listQuestions.Add(listQuestionsMul[x]);
			}
			for(int x=0; x<listAnswersMul.Count; x++)
			{
				listAnswers.Add(listAnswersMul[x]);
			}
		}

		else if(SVM_Script.gameDifficulty=="expert")
		{
			for(int x=0; x<listQuestionsDiv.Count; x++)
			{
				listQuestions.Add(listQuestionsDiv[x]);
			}
			for(int x=0; x<listAnswersDiv.Count; x++)
			{
				listAnswers.Add(listAnswersDiv[x]);
			}
		}
	}

	public Sprite GetQuestion()
	{
		if(listQuestions.Count < 1)
		{
			RepopulateQuestions();
		}
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