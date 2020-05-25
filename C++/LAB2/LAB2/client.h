#pragma once
#include <string>

using namespace std;

namespace business_logic
{
	struct Address
	{
	public:
		std::string district; //*	
		string street;
		int house;

		Address();
		Address(const string& district, const string& street, int house);
		static Address read_address();
	};

	struct Date
	{
	public:
		int year;
		int month;
		int day;

		static const int min_year = 1970;
		static const int min_month = 1;
		static const int min_day = 1;

		Date();
		Date(int year, int month, int day);
		static Date read_date(const string& message = "");
		bool operator==(const Date& rvalue) const;

	private:
		static bool is_leap(int year);
		static int get_days_in_month(int month, int year);
		static int get_current_year();
	};

	struct Client
	{
	public:
		string surname; //*
		string phone;
		Address address;
		int contract_id;
		Date contract_date; //*
		Date last_payment_date; //*
		int installation_fee;
		int subscription_fee;

		Client();
		Client(const string& surname, const string& phone, Address adds, const int id, const Date& contract_date,
		       const Date& payment_date, int install_fee, int sub_fee);
		static Client read_client();
	};

	typedef Client value_type;

	ostream& operator<<(ostream& out, const Address& a);
	ostream& operator<<(ostream& out, const Date& d);
	ostream& operator<<(ostream& out, const Client& c);
	istream& operator>>(istream& in, Address& address);
	istream& operator>>(istream& in, Date& date);
	istream& operator>>(istream& in, Client& client);
}
