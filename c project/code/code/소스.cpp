#include <stdio.h>

#include <Windows.h>

#include <stdlib.h>

#pragma warning(disable:4996)



/*원본 코드는 void Result(void) 함수를 main 함수에서 호출했지만

주석 버전은 모든 작업이 main 함수에서 진행되도록 설정하여 F11 디버깅을

이용하여 코드를 한줄 씩 분석하기에 용이하게 제작하였음을 알림*/



void Result(void);

int Switch(int select);



int main(void) {



	int select = 0;//switch문 제어용 변수



	while (1) {



		int NumOfStudent = 0; //각 반의 학생 수를 담기 위한 변수

		int average[50];//각 학생의 평균점수를 담을 int형 배열변수

		char student[50][10];//학생의 이름을 담을 char형 2차원 배열

		int grade[50][5];//학생의 과목별 성적을 담는 int형 2차원 배열

		int max = 0, top = 0, plusResult = 0;

		//max : 평균점수가 가장 높은 값을 담을 변수(printf로 출력되지는 않음)

		//top : 평균점수가 가장 높은 학생이 몇 번인지를 표시하는 변수

		//plusResult : 각 학생이 받은 점수의 총합



		char subject[5][10] = { //과목명이 담겨있는 변수, 과목명을 미리 초기화해둔 상태

		{"국어"},

		{"영어"},

		{"수학"},

		{"사회"},

		{"과학"}

		};



		printf("학생 수 : ");

		scanf_s("%d", &NumOfStudent);

		//학생 수를 NumOfStudent 변수에 입력하도록 함. 입력한 횟수만큼 아래의 for문을 반복할 수 있음



		for (int i = 0; i < NumOfStudent; i++) {



			printf("%d번 학생 이름: ", i + 1);

			scanf("%s", student[i]);//학생 이름을 먼저 입력받는다



			for (int j = 0; j < 5; j++) { //과목 별 성적입력 란

				printf("%s %s 점수 : ", student[i], subject[j]);

				scanf_s("%d", &grade[i][j]);//학생 이름 입력 후, 각 학생의 성적을 국영수사과 순으로 입력

			}

		}



		system("cls");//화면 클리어, 이후에 성적표 출력



		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);

		//↑텍스트 색 변경 코드, 프로그램 흐름에는 영향을 주지 않음



		printf("***********************우리반 성적표************************\n");

		printf("\t국어\t영어\t수학\t사회\t과학\t총점\t평균\n");



		for (int i = 0; i < NumOfStudent; i++) {



			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);

			plusResult = 0;

			printf("%s\t", student[i]); //학생 이름 출력, 출력 직후 중첩 for문 돌입



			for (int j = 0; j < 5; j++) {



				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);

				printf("%3d\t", grade[i][j]);//각 학생이 받은 점수를 국영수사과 순으로 표기



				plusResult += grade[i][j];//각 학생이 받은 점수의 총합을 plusResult에 누적계산으로 삽입

			}



			average[i] = plusResult / 5;//중첩 for문을 빠져나오자마자, 학생마다 평균점수를 계산하여 average배열에 각각 삽입



			printf("%3d\t%3d\n\n", plusResult, average[i]);

			//각 학생의 총점과 평균 점수를 순차적으로 출력

		}



		max = average[0];

		//0번째의 평균점수를 우선 최고점으로 상정하여 max에 삽입



		for (int i = 0; i < NumOfStudent; i++)



		{

			if (max < average[i]) //max가 i번째의 평균점수보다 낮을 시 아래의 문법 실행

			{

				max = average[i]; //i번째의 평균점수가 현재의 max보다 높기 때문에, i번째의 평균점수를 max에 덮어씌운다

				top = i; //i번째가 현재 성적 1위임을 표시하기 위해 top 변수에 i를 삽입

			}

		}//학생 수가 3명일 시, 3번째 학생의 평균점수까지 계산한 후 for문 탈출



		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);

		printf("************************************************************\n");

		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);



		Sleep(1000);

		printf("이번 시험 1등은 ?\n\n");

		Sleep(1000);

		printf("두구두구두구\n\n");

		Sleep(1000);



		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 13);

		printf("%s!!!!!\n", student[top]);

		//top에는 성적 1위의 번호가 쓰여있음. 따라서 출력하는 학생의 이름은 1등 성적을 받은 학생의 이름임



		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);

		printf("\n다음 보충수업 때부터 심화반으로 가세요\n");

		Sleep(1000);





		printf("다음 반을 입력하려면 1.\t프로그램 종료는 2를 입력해주세요.\n");

		scanf("%d", &select);





		switch (select) { //select에 삽입된 수에 따라 case 1, 2로 구분해서 진행

		case 1: //select가 1일 시 화면 클리어, 그리고 반복문 재반복

			system("cls");

			break;



		case 2: //무한반복 탈출, 프로그램 종료

			printf("\n\n프로그램을 종료합니다...");

			exit(0);

		}

	}

	return 0;

}