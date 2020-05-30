// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
// ReSharper disable StringLiteralTypo
// ReSharper disable IdentifierTypo

#include <iostream>
#include <string>

using namespace std;

namespace console_utils
{
	string& rtrim(std::string& s, const char* symbols = " :")
	{
		s.erase(s.find_last_not_of(symbols) + 1);
		return s;
	}

	string& ltrim(std::string& s, const char* symbols = " :")
	{
		s.erase(0, s.find_first_not_of(symbols));
		return s;
	}

	string& trim(std::string& s, const char* symbols = " :")
	{
		return ltrim(rtrim(s, symbols), symbols);
	}

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

	bool is_letter(const char& c)
	{
		return c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z';
	}

	bool is_containing_only_letters(const string& s)
	{
		bool correct = s.length() > 0;
		for (size_t i = 0; i < s.length() && correct; ++i)
		{
			correct = is_letter(s[i]);
		}
		return correct;
	}

	bool is_digit(const char& c)
	{
		return c >= '0' && c <= '9';
	}

	bool is_phone_number(const string& s)
	{
		bool correct = s.length() == 11;
		for (size_t i = 0; i < s.length() && correct; ++i)
		{
			correct = is_digit(s[i]);
		}
		return correct;
	}

	string input_string(const string& message, bool predicate(const string& s))
	{
		string rv;
		cout << "\n" + message + " --> ";
		cin >> rv;
		while (!predicate(trim(rv)))
		{
			cout << "Ошибка, введите снова --> ";
			cin >> rv;
		}
		return rv;
	}

	string input_filename(const string& message)
	{
		return input_string(message, is_correct_filename);
	}

	int input_number(const string& message, const int min, const int max)
	{
		int rv = 0;
		string tmp;
		bool correct;
		cout << "\n" + message + " --> ";
		do
		{
			correct = true;
			cin >> tmp;
			try
			{
				rv = stoi(tmp);
			}
			catch (exception&)
			{
				correct = false;
			}
			if (!correct || rv < min || rv > max)
				cout << "Ошибка, введите снова --> ";
		}
		while (!correct || rv < min || rv > max);
		return rv;
	}

	string read_value(istream& in)
	{
		const string delimiter = ":";
		string source;
		getline(in, source);
		const unsigned int pos = source.find(delimiter);
		if (pos == string::npos)
			throw runtime_error("Не удалось считать информацию из файла.");
		string result = source.substr(pos + delimiter.length(), source.length());
		return trim(result);
	}

	string get_value(string& source, const string& delimiter)
	{
		unsigned int pos = source.find(delimiter);
		if (pos == string::npos)
			pos = source.length();
		string result = source.substr(0, pos);
		source.erase(0, pos + delimiter.length());
		return trim(result);
	}
}
