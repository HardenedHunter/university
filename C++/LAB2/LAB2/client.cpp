// ReSharper disable StringLiteralTypo
// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
#include "client.h"
#include <chrono>
#include <iostream>
#include <string>
#include "console_utils.h"

using namespace std;
using namespace chrono;
using namespace console_utils;

namespace business_logic
{
	Address::Address(): house(1)
	{
	}

	Address::Address(const string& district, const string& street, const int house)
	{
		if (!is_containing_only_letters(district))
			throw runtime_error("Название района может состоять только из букв.");
		if (!is_containing_only_letters(street))
			throw runtime_error("Название улицы может состоять только из букв.");
		if (house <= 0)
			throw runtime_error("Номер дома должен быть больше или равен 1.");

		this->district = district;
		this->street = street;
		this->house = house;
	}

	Address Address::read_address()
	{
		cout << endl << "Введите адрес:" << endl;
		const string district = input_string("Введите район проживания", is_containing_only_letters);
		const string street = input_string("Введите улицу", is_containing_only_letters);
		const int house = input_number("Введите номер дома", 1, INT32_MAX);
		return {district, street, house};
	}

	Date::Date(): year(min_year), month(min_month), day(min_day)
	{
	};

	Date::Date(const int year, const int month, const int day)
	{
		const int current_year = get_current_year();
		if (year < min_year || year > current_year)
			throw runtime_error("Некорректное значение для года.");
		if (month < 1 || month > 12)
			throw runtime_error("Некорректное значение для месяца.");
		if (day < 1 || day > get_days_in_month(month, year))
			throw runtime_error("Некорректное значение для дня.");
		this->year = year;
		this->month = month;
		this->day = day;
	}

	Date Date::read_date(const string& message)
	{
		cout << endl;
		if (message.length() > 0)
			cout << message << endl;
		const int current_year = get_current_year();
		const int year = input_number("Введите год", min_year, current_year);
		const int month = input_number("Введите месяц", 1, 12);
		const int day = input_number("Введите день", 1, get_days_in_month(month, year));
		return {year, month, day};
	}

	// bool Date::operator==(const Date& lvalue, const Date& rvalue)
	// {
	// 	return lvalue.year = rvalue.year && lvalue.day == rvalue.day && lvalue.month == rvalue.month;
	// }

	bool Date::operator==(const Date& rvalue) const
	{
		return year == rvalue.year && day == rvalue.day && month == rvalue.month;
	}

	bool Date::is_leap(const int year)
	{
		return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
	}

	int Date::get_days_in_month(const int month, const int year)
	{
		switch (month)
		{
		case 2:
			return 28 + is_leap(year);
		case 1: case 3: case 5: case 7: case 8: case 10: case 12:
			return 31;
		case 4: case 6: case 9: case 11:
			return 30;
		default:
			return 0;
		}
	}

	int Date::get_current_year()
	{
		const time_t tt = system_clock::to_time_t(system_clock::now());
		tm time{};
		localtime_s(&time, &tt);
		return time.tm_year + 1900;
	}


	Client::Client() : contract_id(0), installation_fee(0), subscription_fee(0)
	{
	}

	Client::Client(const string& surname, const string& phone, Address adds, const int id, const Date& contract_date,
	               const Date& payment_date, const int install_fee, const int sub_fee) : address(move(adds)),
	                                                                                     contract_date(contract_date),
	                                                                                     last_payment_date(payment_date)
	{
		if (!is_containing_only_letters(surname))
			throw runtime_error("Название района может состоять только из букв.");
		if (!is_phone_number(phone))
			throw runtime_error("Название района может состоять только из букв.");
		if (id <= 0)
			throw runtime_error("Номер договора должен быть больше или равен 1.");
		//contract Date should be less than or equal to payment Date
		if (install_fee < 0)
			throw runtime_error("Оплата за установку не может быть отрицательной.");
		if (sub_fee < 0)
			throw runtime_error("Ежемесячная оплата не может быть отрицательной.");

		this->surname = surname;
		this->phone = phone;
		this->contract_id = id;
		this->installation_fee = install_fee;
		this->subscription_fee = sub_fee;
	}

	Client Client::read_client()
	{
		const string surname = input_string("Введите фамилию абонента", is_containing_only_letters);
		const string phone = input_string("Введите номер телефона", is_phone_number);
		const Address adds = Address::read_address();
		const int id = input_number("Введите номер договора", 1, 10000);
		const Date contract_date = Date::read_date("Введите дату заключения договора");
		const Date payment_date = Date::read_date("Введите дату последнего платежа");
		const int install_fee = input_number("Введите плату за установку", 0, INT32_MAX);
		const int sub_fee = input_number("Введите ежемесячную оплату", 0, INT32_MAX);
		return {surname, phone, adds, id, contract_date, payment_date, install_fee, sub_fee};
	}

	ostream& operator<<(std::ostream& out, const Date& d)
	{
		out << d.day << "." << d.month << "." << d.year;
		return out;
	}

	ostream& operator<<(std::ostream& out, const Address& a)
	{
		out << a.district << ", " << a.street << ", " << a.house;
		return out;
	}

	ostream& operator<<(std::ostream& out, const Client& c)
	{
		out << endl << "Фамилия: " << c.surname << endl;
		out << "Телефон: " << c.phone << endl;
		out << "Адрес: " << c.address << endl;
		out << "Номер договора: " << c.contract_id << endl;
		out << "Дата заключения договора: " << c.contract_date << endl;
		out << "Дата последнего платежа: " << c.last_payment_date << endl;
		out << "Плата за установку: " << c.installation_fee << endl;
		out << "Ежемесячная оплата: " << c.subscription_fee << endl;
		return out;
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

	std::istream& operator>>(istream& in, Address& address)
	{
		string tmp = read_value(in);
		const string delimiter = ", ";
		const string district = get_value(tmp, delimiter);
		const string street = get_value(tmp, delimiter);
		const int house = stoi(get_value(tmp, delimiter));
		address = {district, street, house};

		return in;
	}

	istream& operator>>(istream& in, Date& date)
	{
		string tmp = read_value(in);
		const string delimiter = ".";
		const int day = stoi(get_value(tmp, delimiter));
		const int month = stoi(get_value(tmp, delimiter));
		const int year = stoi(get_value(tmp, delimiter));
		date = {year, month, day};

		return in;
	}

	istream& operator>>(istream& in, Client& client)
	{
		const string surname = read_value(in);
		const string phone = read_value(in);
		Address address;
		in >> address;
		const int id = stoi(read_value(in));
		Date contract_date;
		in >> contract_date;
		Date payment_date;
		in >> payment_date;
		const int install_fee = stoi(read_value(in));
		const int sub_fee = stoi(read_value(in));
		client = {surname, phone, address, id, contract_date, payment_date, install_fee, sub_fee};
		string tmp;
		getline(in, tmp);
		return in;
	}
}
