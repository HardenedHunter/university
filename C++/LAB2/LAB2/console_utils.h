// ReSharper disable CommentTypo
#pragma once
#include <string>

using namespace std;

namespace console_utils
{
	//Удаление лишних символов с обеих сторон
	string& trim(std::string& s, const char* symbols = " :");
	
	//Проверка имени файла на корректность
	bool is_correct_filename(const string& filename);

	//Проверка строки на содержание только букв
	bool is_containing_only_letters(const string& s);
	
	//Проверка, что строка является номером телефона
	bool is_phone_number(const string& s);
	
	//Ввод строки
	string input_string(const string& message, bool predicate(const string& s));
	
	//Ввод имени файла
	string input_filename(const string& message);

	//Ввод числа в заданном диапазоне
	int input_number(const string& message, int min, int max);

	//Чтение информации из потока
	string read_value(istream& in);

	//Парсинг строки
	string get_value(string& source, const string& delimiter);
}
