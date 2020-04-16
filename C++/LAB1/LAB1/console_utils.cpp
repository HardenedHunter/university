// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
// ReSharper disable StringLiteralTypo

#include <iostream>
#include "vector_utils.h"

using namespace std;
using namespace vector_utils;

namespace console_utils
{
	bool is_correct_filename(const string& filename)
	{
		string invalid_characters = "\\/:?*<>|";
		bool rv = true;
		unsigned int i = 0, j = 0;
		while (i < filename.length() && rv)
		{
			j = 0;
			while (j < invalid_characters.length() && rv)
			{
				rv = filename[i] != invalid_characters[j];
				j++;
			}
			i++;
		}
		return rv;
	}

	string input_filename(const string& message)
	{
		string rv;
		cout << "\n" + message + " --> ";
		cin >> rv;
		while (!is_correct_filename(rv))
		{
			cout << "������, ������� ����� --> ";
			cin >> rv;
		}
		return rv;
	}

	int input_number(const string& message, const int min, const int max)
	{
		int rv;
		cout << "\n" + message + " --> ";
		cin >> rv;
		while (rv < min || rv > max)
		{
			cout << "������, ������� ����� --> ";
			cin >> rv;
		}
		return rv;
	}

	int render_menu()
	{
		const int menu_size = 9;

		std::cout << std::endl << "1: ��������� ���� �������." << endl;
		cout << "2: ��������� ��������� ������� �� �����." << endl;
		cout << "3: ������������� ��������� (����)." << endl;
		cout << "4: ������������� ��������� (std::transform)." << endl;
		cout << "5: ������������� ��������� (std::for_each)." << endl;
		cout << "6: ����� ����� ����� � ����������." << endl;
		cout << "7: ����� ������� �������������� ����� � ����������." << endl;
		cout << "8: ����� ���������� � �������." << endl;
		cout << "9: ����� ���������� � ����." << endl;
		cout << "0: Exit" << endl;
		return input_number("", 0, menu_size);;
	}

	void render_fill_file()
	{
		const string filename = input_filename("������� ��� �����");
		const int count = input_number("������� ���-�� �����", 1, 100);
		const int range = input_number("������� ��������:", 1, INT32_MAX);
		fill_file(filename, count, range);
	}

	void render_fill_container(container& target)
	{
		const string filename = input_filename("������� ��� �����");
		try
		{
			target = fill_container(filename);
		}
		catch (exception& e)
		{
			cout << e.what() << endl;
		}
	}

	void render_modify(container& source, container modifier(const container&))
	{
		if (source.empty())
		{
			cout << "��������� ����." << endl;
		}
		else
		{
			container result = modifier(source);
			cout << "���������� ���������:" << endl;
			print_container(result);
		}
	}

	void render_sum(container& source)
	{
		cout << "����� ���������: " << sum(source) << endl;
	}

	void render_average(container& source)
	{
		cout << "������� �������������� ���������: " << average(source) << endl;
	}

	void render_console_print(container& source)
	{
		if (source.empty())
			cout << "��������� ����." << endl;
		else
		{
			print_container(source);
		}
	}

	void render_file_print(container& source)
	{
		if (source.empty())
			cout << "��������� ����." << endl;
		else
		{
			const string filename = input_filename("������� ��� �����");
			fill_file(filename, source);
		}
	}

	void render()
	{
		container primary;
		int choice = -1;
		while (choice != 0)
		{
			choice = render_menu();
			switch (choice)
			{
			case 1: render_fill_file();
				break;
			case 2: render_fill_container(primary);
				break;
			case 3: render_modify(primary, modify);
				break;
			case 4: render_modify(primary, modify_transform);
				break;
			case 5: render_modify(primary, modify_foreach);
				break;
			case 6: render_sum(primary);
				break;
			case 7: render_average(primary);
				break;
			case 8: render_console_print(primary);
				break;
			case 9: render_file_print(primary);
				break;
			default: break;
			}
		}
	}
}
