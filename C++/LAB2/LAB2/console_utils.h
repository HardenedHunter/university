// ReSharper disable CommentTypo
#pragma once
#include <string>

using namespace std;

namespace console_utils
{
	//�������� ������ �������� � ����� ������
	string& trim(std::string& s, const char* symbols = " :");
	
	//�������� ����� ����� �� ������������
	bool is_correct_filename(const string& filename);

	//�������� ������ �� ���������� ������ ����
	bool is_containing_only_letters(const string& s);
	
	//��������, ��� ������ �������� ������� ��������
	bool is_phone_number(const string& s);
	
	//���� ������
	string input_string(const string& message, bool predicate(const string& s));
	
	//���� ����� �����
	string input_filename(const string& message);

	//���� ����� � �������� ���������
	int input_number(const string& message, int min, int max);

	//������ ���������� �� ������
	string read_value(istream& in);

	//������� ������
	string get_value(string& source, const string& delimiter);
}
