#include <stdio.h>

#include <Windows.h>

#include <stdlib.h>

#pragma warning(disable:4996)



/*���� �ڵ�� void Result(void) �Լ��� main �Լ����� ȣ��������

�ּ� ������ ��� �۾��� main �Լ����� ����ǵ��� �����Ͽ� F11 �������

�̿��Ͽ� �ڵ带 ���� �� �м��ϱ⿡ �����ϰ� �����Ͽ����� �˸�*/



void Result(void);

int Switch(int select);



int main(void) {



	int select = 0;//switch�� ����� ����



	while (1) {



		int NumOfStudent = 0; //�� ���� �л� ���� ��� ���� ����

		int average[50];//�� �л��� ��������� ���� int�� �迭����

		char student[50][10];//�л��� �̸��� ���� char�� 2���� �迭

		int grade[50][5];//�л��� ���� ������ ��� int�� 2���� �迭

		int max = 0, top = 0, plusResult = 0;

		//max : ��������� ���� ���� ���� ���� ����(printf�� ��µ����� ����)

		//top : ��������� ���� ���� �л��� �� �������� ǥ���ϴ� ����

		//plusResult : �� �л��� ���� ������ ����



		char subject[5][10] = { //������� ����ִ� ����, ������� �̸� �ʱ�ȭ�ص� ����

		{"����"},

		{"����"},

		{"����"},

		{"��ȸ"},

		{"����"}

		};



		printf("�л� �� : ");

		scanf_s("%d", &NumOfStudent);

		//�л� ���� NumOfStudent ������ �Է��ϵ��� ��. �Է��� Ƚ����ŭ �Ʒ��� for���� �ݺ��� �� ����



		for (int i = 0; i < NumOfStudent; i++) {



			printf("%d�� �л� �̸�: ", i + 1);

			scanf("%s", student[i]);//�л� �̸��� ���� �Է¹޴´�



			for (int j = 0; j < 5; j++) { //���� �� �����Է� ��

				printf("%s %s ���� : ", student[i], subject[j]);

				scanf_s("%d", &grade[i][j]);//�л� �̸� �Է� ��, �� �л��� ������ ��������� ������ �Է�

			}

		}



		system("cls");//ȭ�� Ŭ����, ���Ŀ� ����ǥ ���



		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);

		//���ؽ�Ʈ �� ���� �ڵ�, ���α׷� �帧���� ������ ���� ����



		printf("***********************�츮�� ����ǥ************************\n");

		printf("\t����\t����\t����\t��ȸ\t����\t����\t���\n");



		for (int i = 0; i < NumOfStudent; i++) {



			SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);

			plusResult = 0;

			printf("%s\t", student[i]); //�л� �̸� ���, ��� ���� ��ø for�� ����



			for (int j = 0; j < 5; j++) {



				SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);

				printf("%3d\t", grade[i][j]);//�� �л��� ���� ������ ��������� ������ ǥ��



				plusResult += grade[i][j];//�� �л��� ���� ������ ������ plusResult�� ����������� ����

			}



			average[i] = plusResult / 5;//��ø for���� ���������ڸ���, �л����� ��������� ����Ͽ� average�迭�� ���� ����



			printf("%3d\t%3d\n\n", plusResult, average[i]);

			//�� �л��� ������ ��� ������ ���������� ���

		}



		max = average[0];

		//0��°�� ��������� �켱 �ְ������� �����Ͽ� max�� ����



		for (int i = 0; i < NumOfStudent; i++)



		{

			if (max < average[i]) //max�� i��°�� ����������� ���� �� �Ʒ��� ���� ����

			{

				max = average[i]; //i��°�� ��������� ������ max���� ���� ������, i��°�� ��������� max�� ������

				top = i; //i��°�� ���� ���� 1������ ǥ���ϱ� ���� top ������ i�� ����

			}

		}//�л� ���� 3���� ��, 3��° �л��� ����������� ����� �� for�� Ż��



		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 14);

		printf("************************************************************\n");

		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);



		Sleep(1000);

		printf("�̹� ���� 1���� ?\n\n");

		Sleep(1000);

		printf("�α��α��α�\n\n");

		Sleep(1000);



		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 13);

		printf("%s!!!!!\n", student[top]);

		//top���� ���� 1���� ��ȣ�� ��������. ���� ����ϴ� �л��� �̸��� 1�� ������ ���� �л��� �̸���



		SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), 15);

		printf("\n���� ������� ������ ��ȭ������ ������\n");

		Sleep(1000);





		printf("���� ���� �Է��Ϸ��� 1.\t���α׷� ����� 2�� �Է����ּ���.\n");

		scanf("%d", &select);





		switch (select) { //select�� ���Ե� ���� ���� case 1, 2�� �����ؼ� ����

		case 1: //select�� 1�� �� ȭ�� Ŭ����, �׸��� �ݺ��� ��ݺ�

			system("cls");

			break;



		case 2: //���ѹݺ� Ż��, ���α׷� ����

			printf("\n\n���α׷��� �����մϴ�...");

			exit(0);

		}

	}

	return 0;

}