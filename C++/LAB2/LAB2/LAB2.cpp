// ReSharper disable StringLiteralTypo
#include <clocale>
#include <cstdlib>
#include <ctime>
#include <iostream>
#include "console_utils.h"

#include "render_utils.h"

using namespace render_utils;
using namespace console_utils;

void setup()
{
	setlocale(LC_ALL, "Russian");
	srand(time(nullptr));
	rand();
}

// void print_container(container& source)
// {

// }
string read(istream& in)
{
	const string delimiter = ":";
	string source;
	getline(in, source);
	const unsigned int pos = source.find(delimiter);
	if (pos == string::npos)
		throw runtime_error("Не удалось считать адрес из файла.");
	const string result = source.substr(pos + delimiter.length(), source.length());
	return result;
}

int main()
{
	setup();
	// string s = read(cin);
	// std::cout << s;
	// int a = input_number("", 1, 10);
	render();
}

