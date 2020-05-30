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
	out << "Файл: " << config.filename << endl << endl;
	return out;
}

Catalog Config::load()
{
	Catalog result;

	ifstream cfg_in(config_filename);
	try
	{
		cout << "Загрузка файла конфигурации..." << endl;
		cfg_in >> *this;
		cout << "Конфигурация загружена." << endl;
	}
	catch (exception&)
	{
		cout << "Произошла ошибка при открытии файла конфигурации." << endl;
		filename = db_filename;
		create_config_file();
	}
	cfg_in.close();

	ifstream db_in(filename);
	if (db_in.is_open())
	{
		try
		{
			cout << "Загрузка данных..." << endl;
			db_in >> result;
			cout << "Загружено записей: " << result.size() << "." << endl;
		}
		catch (exception&)
		{
			cout << "Произошла ошибка при открытии файла с данными." << endl;
		}
	}
	else
	{
		cout << "Файл с данными не найден." << endl;
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
		cout << "Cохранение..." << endl;
		db_out << catalog;
		cout << "Сохранение прошло успешно." << endl;
	}
	catch (exception& e)
	{
		cout << "Ошибка при записи информации в файл." << endl;
	}
	db_out.close();
}

void Config::create_config_file() const
{
	ofstream cfg_out(config_filename);
	try
	{
		cfg_out << *this;
		cout << "Создан новый файл конфигурации." << endl;
	}
	catch (exception& e)
	{
		cout << "Ошибка при создании файла конфигурации." << endl;
	}
	cfg_out.close();
}
