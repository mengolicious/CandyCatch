using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuestionManagerScript : MonoBehaviour {

	public List<Sprite> listQuestions; 
	public List<int> listAnswers; 

	public List<Sprite> listQuestionsMul; 
	public List<int> listAnswersMul;

	public List<Sprite> listQuestionsDiv; 
	public List<int> listAnswersDiv;

	public int tempRandNum;
	public Sprite tempQuestion;
	public int tempAnswer;

	public ScoreManagerScript SM_Script;

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

	// Use this for initialization
	void Start ()
	{

		listQuestions = new List<Sprite>();
		//Start questions for Addition
		listQuestions.Add(Q1);
		listQuestions.Add(Q2);
		listQuestions.Add(Q3);
		listQuestions.Add(Q4);
		listQuestions.Add(Q5);
		listQuestions.Add(Q6);
		listQuestions.Add(Q7);
		listQuestions.Add(Q8);
		listQuestions.Add(Q9);
		listQuestions.Add(Q10);
		listQuestions.Add(Q11);
		listQuestions.Add(Q12);
		listQuestions.Add(Q13);
		listQuestions.Add(Q14);
		listQuestions.Add(Q15);
		listQuestions.Add(Q16);
		listQuestions.Add(Q17);
		listQuestions.Add(Q18);
		listQuestions.Add(Q19);
		listQuestions.Add(Q20);
		//END questions for Addition
		//Start questions for Subtraction
		listQuestions.Add(Q21);
		listQuestions.Add(Q22);
		listQuestions.Add(Q23);
		listQuestions.Add(Q24);
		listQuestions.Add(Q25);
		listQuestions.Add(Q26);
		listQuestions.Add(Q27);
		listQuestions.Add(Q28);
		listQuestions.Add(Q29);
		listQuestions.Add(Q30);
		listQuestions.Add(Q31);
		listQuestions.Add(Q32);
		listQuestions.Add(Q33);
		listQuestions.Add(Q34);
		listQuestions.Add(Q35);
		listQuestions.Add(Q36);
		listQuestions.Add(Q37);
		listQuestions.Add(Q38);
		listQuestions.Add(Q39);
		listQuestions.Add(Q40);
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

		if(SVM_Script.gameDifficulty=="advance" || SVM_Script.gameDifficulty=="expert")
		{
			for(int x=0; x<listQuestionsMul.Count; x++)
			{
				listQuestions.Add(listQuestionsMul[x]);
			}
		}

		if(SVM_Script.gameDifficulty=="expert")
		{
			for(int x=0; x<listQuestionsDiv.Count; x++)
			{
				listQuestions.Add(listQuestionsDiv[x]);
			}
		}

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

		listAnswers = new List<int> ();
		//Start of answer for Addition
		listAnswers.Add(5);
		listAnswers.Add(4);
		listAnswers.Add(9);
		listAnswers.Add(9);
		listAnswers.Add(5);

		listAnswers.Add(8);
		listAnswers.Add(4);
		listAnswers.Add(6);
		listAnswers.Add(8);
		listAnswers.Add(9);

		listAnswers.Add(2);
		listAnswers.Add(4);
		listAnswers.Add(3);
		listAnswers.Add(1);
		listAnswers.Add(6);

		listAnswers.Add(1);
		listAnswers.Add(2);
		listAnswers.Add(2);
		listAnswers.Add(4);
		listAnswers.Add(6);
		//END of answer for Addition

		//Start of answer for Subtration
		listAnswers.Add(1);
		listAnswers.Add(5);
		listAnswers.Add(6);
		listAnswers.Add(8);
		listAnswers.Add(5);

		listAnswers.Add(5);
		listAnswers.Add(8);
		listAnswers.Add(9);
		listAnswers.Add(9);
		listAnswers.Add(9);

		listAnswers.Add(2);
		listAnswers.Add(9);
		listAnswers.Add(8);
		listAnswers.Add(6);
		listAnswers.Add(4);

		listAnswers.Add(9);
		listAnswers.Add(4);
		listAnswers.Add(7);
		listAnswers.Add(7);
		listAnswers.Add(1);
		//END of answer for Subtration

		if(SVM_Script.gameDifficulty=="advance" || SVM_Script.gameDifficulty=="expert")
		{
			for(int x=0; x<listAnswersMul.Count; x++)
			{
				listAnswers.Add(listAnswersMul[x]);
			}
		}

		if(SVM_Script.gameDifficulty=="expert")
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
		// -------populate with new questions and answers ------- //
		
		// -------- end population ------------------ //
	}
}