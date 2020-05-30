// ReSharper disable StringLiteralTypo
// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
// ReSharper disable CppJoinDeclarationAndAssignment
#include "render_utils.h"

#include <fstream>
#include <iostream>
#include <iterator>

#include "catalog.h"
#include "console_utils.h"
#include "config.h"

using namespace console_utils;

int render_utils::render_menu()
{
	const int menu_size = 8;

	cout << endl;
	cout << "1: Посмотреть содержимое справочника." << endl;
	cout << "2: Добавить абонента." << endl;
	cout << "3: Изменить абонента." << endl;
	cout << "4: Удалить абонента." << endl;
	cout << "5: Найти абонента." << endl;
	cout << "6: Очистить справочник." << endl;
	cout << "7: Добавить данные из файла." << endl;
	cout << "8: Сохранить данные в файл." << endl;
	cout << "0: Exit" << endl;
	const int choice = input_number("", 0, menu_size);
	cout << endl;
	return choice;
}

int render_utils::render_search_menu()
{
	const int menu_size = 4;

	cout << endl;
	cout << "1: Найти по фамилии." << endl;
	cout << "2: Найти по району." << endl;
	cout << "3: Найти по дате заключения договора." << endl;
	cout << "4: Найти по дате последнего платежа." << endl;
	cout << "0: Exit" << endl;
	const int choice = input_number("", 0, menu_size);
	cout << endl;
	return choice;
}

int render_algorithm_menu()
{
	const int menu_size = 2;

	cout << endl;
	cout << "1: Бинарный поиск." << endl;
	cout << "2: Линейный поиск." << endl;
	const int choice = input_number("", 1, menu_size);
	cout << endl;
	return choice;
}

void render_utils::render()
{
	Config config;
	Catalog catalog = config.load();
	int choice = -1;
	while (choice != 0)
	{
		choice = render_menu();
		switch (choice)
		{
		case 1: render_print(catalog);
			break;
		case 2: render_add(catalog);
			break;
		case 3: render_update(catalog);
			break;
		case 4: render_remove(catalog);
			break;
		case 5: render_search(catalog);
			break;
		case 6: render_clear(catalog);
			break;
		case 7: render_add_from_file(catalog);
			break;
		case 8: render_save_to_file(catalog);
			break;
		default: break;
		}
	}
	if (catalog.get_version() != 0)
		config.save(catalog);
}

container search_surname(Catalog catalog, const bool use_binary_search = false)
{
	const string surname = input_string("Введите фамилию абонента", is_containing_only_letters);
	if (use_binary_search)
	{
		catalog.sort([](const Client& lvalue, const Client& rvalue)
		{
			return compare(lvalue.surname, rvalue.surname) < 0;
		});
		const function<string(const Client&)> get_info = [](const Client& client) { return client.surname; };
		return catalog.binary_search(surname, get_info);
	}
	return catalog.linear_search([&surname](const Client& client)
	{
		return client.surname == surname;
	});
}

container search_district(Catalog catalog, bool use_binary_search = false)
{
	const string district = input_string("Введите район проживания", is_containing_only_letters);
	if (use_binary_search)
	{
		catalog.sort([](const Client& lvalue, const Client& rvalue)
		{
			return compare(lvalue.address.district, rvalue.address.district) < 0;
		});
		const function<string(const Client&)> get_info = [](const Client& client) { return client.address.district; };
		return catalog.binary_search(district, get_info);
	}
	return catalog.linear_search([&district](const Client& client)
	{
		return client.address.district == district;
	});
}

container search_contract_date(Catalog catalog, bool use_binary_search = false)
{
	Date date = Date::read_date("Введите дату заключения договора");
	if (use_binary_search)
	{
		catalog.sort([](const Client& lvalue, const Client& rvalue)
		{
			return compare(lvalue.contract_date, rvalue.contract_date) < 0;
		});
		const function<Date(const Client&)> get_info = [](const Client& client) { return client.contract_date; };
		return catalog.binary_search(date, get_info);
	}
	return catalog.linear_search([date](const Client& client)
	{
		return client.contract_date == date;
	});
}

container search_last_payment_date(Catalog catalog, bool use_binary_search = false)
{
	Date date = Date::read_date("Введите дату последнего платежа");
	if (use_binary_search)
	{
		catalog.sort([](const Client& lvalue, const Client& rvalue)
		{
			return compare(lvalue.last_payment_date, rvalue.last_payment_date) < 0;
		});
		const function<Date(const Client&)> get_info = [](const Client& client) { return client.last_payment_date; };
		return catalog.binary_search(date, get_info);
	}
	return catalog.linear_search([date](const Client& client)
	{
		return client.last_payment_date == date;
	});
}

void render_utils::render_search(const Catalog& catalog)
{
	auto search_function = search_surname;
	container result;
	int choice = -1;

	while (choice != 0)
	{
		choice = render_search_menu();
		switch (choice)
		{
		case 1: search_function = search_surname;
			break;
		case 2: search_function = search_district;
			break;
		case 3: search_function = search_contract_date;
			break;
		case 4: search_function = search_last_payment_date;
			break;
		default: break;
		}

		if (choice > 0)
		{
			const bool use_binary_search = render_algorithm_menu() == 1;
			result = search_function(catalog, use_binary_search);

			if (result.empty())
			{
				cout << endl << "Ничего не найдено." << endl;
			}
			else
			{
				for (const Client& value : result)
					cout << value << endl;
				cout << "Найдено записей: " << result.size() << "." << endl;
			}
		}

		result.clear();
	}
}

void render_utils::render_print(const Catalog& catalog)
{
	catalog.print();
}

void render_utils::render_add(Catalog& c)
{
	const Client cl = Client::read_client();
	try
	{
		c.add(cl);
	}
	catch (invalid_argument& e)
	{
		cout << e.what();
	}
}

void render_utils::render_update(Catalog& catalog)
{
	const int id = input_number("Введите номер договора", 1, INT32_MAX);
	if (!catalog.contains(id))
		cout << "Абонент не найден в базе." << endl;

	cout << "Введите новые данные об абоненте." << endl;

	const string surname = input_string("Введите фамилию абонента", is_containing_only_letters);
	const string phone = input_string("Введите номер телефона", is_phone_number);
	const Address adds = Address::read_address();
	const Date contract_date = Date::read_date("Введите дату заключения договора");
	const Date payment_date = Date::read_date("Введите дату последнего платежа");
	const int install_fee = input_number("Введите плату за установку", 0, INT32_MAX);
	const int sub_fee = input_number("Введите ежемесячную оплату", 0, INT32_MAX);

	Client client = Client(surname, phone, adds, id, contract_date, payment_date, install_fee, sub_fee);

	catalog.update(client);
}

void render_utils::render_remove(Catalog& catalog)
{
	const int id = input_number("Введите номер договора", 1, INT32_MAX);
	if (catalog.remove(id))
		cout << "Абонент с номером контракта " << id << " успешно удалён." << endl;
	else
		cout << "Абонент не найден в базе" << endl;
}

void render_utils::render_clear(Catalog& catalog)
{
	catalog.clear();
	cout << "Справочник очищен." << endl;
}

void render_utils::render_add_from_file(Catalog& catalog)
{
	const string filename = input_filename("Введите имя файла (с расширением)");
	ifstream in(filename);
	if (!in.is_open())
		cout << "Ошибка при открытии файла." << endl;
	else
	{
		const int size = catalog.size();
		try
		{
			in >> catalog;
			cout << "Добавлено новых записей: " << catalog.size() - size << "." << endl;
		}
		catch (exception&)
		{
			catalog.shrink(size);
			cout << "Ошибка при чтении информации из файла." << endl;
		}
		in.close();
	}
}

void render_utils::render_save_to_file(Catalog& catalog)
{
	if (catalog.empty())
		cout << "Справочник пуст." << endl;
	else
	{
		const string filename = input_filename("Введите имя файла (с расширением)");
		ofstream out(filename);
		if (!out.is_open())
			cout << "Ошибка при открытии файла." << endl;
		else
		{
			try
			{
				out << catalog;
				cout << "Данные успешно сохранены." << endl;
			}
			catch (exception& e)
			{
				cout << "Ошибка при записи информации в файл." << endl;
			}
			out.close();
		}
	}
}
