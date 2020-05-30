#include "config.h"
#include <iostream>
#include <fstream>

istream& operator>>(istream& in, Config& config)
{
	const string filename = read_value(in);
	config.filename = filename;
	return in;
}

ostream& operator<<(ostream& out, const Config& config)
{
	out << "����: " << config.filename << endl << endl;
	return out;
}

Catalog Config::load()
{
	Catalog result;

	ifstream cfg_in(config_filename);
	try
	{
		cout << "�������� ����� ������������..." << endl;
		cfg_in >> *this;
		cout << "������������ ���������." << endl;
	}
	catch (exception&)
	{
		cout << "��������� ������ ��� �������� ����� ������������." << endl;
		filename = db_filename;
		create_config_file();
	}
	cfg_in.close();

	ifstream db_in(filename);
	if (db_in.is_open())
	{
		try
		{
			cout << "�������� ������..." << endl;
			db_in >> result;
			cout << "��������� �������: " << result.size() << "." << endl;
		}
		catch (exception&)
		{
			cout << "��������� ������ ��� �������� ����� � �������." << endl;
		}
	}
	else
	{
		cout << "���� � ������� �� ������." << endl;
	}

	db_in.close();
	result.reset_version();
	return result;
}

void Config::save(const Catalog& catalog) const
{
	ofstream db_out(filename);

	try
	{
		cout << "C���������..." << endl;
		db_out << catalog;
		cout << "���������� ������ �������." << endl;
	}
	catch (exception& e)
	{
		cout << "������ ��� ������ ���������� � ����." << endl;
	}
	db_out.close();
}

void Config::create_config_file() const
{
	ofstream cfg_out(config_filename);
	try
	{
		cfg_out << *this;
		cout << "������ ����� ���� ������������." << endl;
	}
	catch (exception& e)
	{
		cout << "������ ��� �������� ����� ������������." << endl;
	}
	cfg_out.close();
}
