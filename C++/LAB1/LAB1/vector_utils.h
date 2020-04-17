// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

#pragma once
#include <string>
#include <vector>

using namespace std;

namespace vector_utils
{
	typedef unsigned uint;
	typedef int value_type;
	typedef vector<value_type> container;
	typedef vector<value_type>::iterator iter;
	typedef vector<value_type>::const_iterator const_iter;

	//��������� ���������� ����� �� -range �� range
	int randint(uint range);

	//���������� ����� ���������� ������� �� -range �� range
	void fill_file(const string& filename, uint count, uint range);

	//���������� ����� �� ����������
	void fill_file(const string& filename, const container& source);

	//���������� ���������� �� �����
	container fill_container(ifstream& in);

	//���������� ���������� �� �����
	container fill_container(const string& filename);

	//���������� ������������� �������� � ����������
	value_type max(const_iter first, const const_iter& last);

	//�������������� ��������� � ������� �����
	container modify(const_iter first, const const_iter& last);

	//�������������� ���������� � ������� �����
	container modify(const container& source);

	//�������������� ���������� � ������� std::transform
	container modify_transform(const container& source);

	//�������������� ���������� � ������� std::for_each
	container modify_foreach(const container& source);

	//���������� ����� ��������� ����������
	int sum(const container& source);

	//���������� �������� ��������������� ���������
	double average(const container& source);

	//������ ���������� � �������
	void print_container(container& source);
}
