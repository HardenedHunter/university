// ReSharper disable StringLiteralTypo
// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
#include "catalog.h"
#include <algorithm>
#include <functional>
#include <iostream>
#include <iterator>

using namespace std;

bool Catalog::add(const Client& client)
{
	const bool result = !contains(client.contract_id);
	if (!result)
		cout << "Абонент с номером контракта " << client.contract_id << " уже есть в базе." << endl;
	else
		clients_.emplace_back(client);
	return result;
}

void Catalog::print() const
{
	if (clients_.empty())
		cout << "Справочник пуст." << endl;
	else
		for (const Client& value : clients_)
			cout << value << endl;
	cout << endl;
}

bool Catalog::contains(const int id) const
{
	return any_of(clients_.begin(), clients_.end(), [&id](const Client& other)
	{
		return (id == other.contract_id);
	});
}

bool Catalog::empty() const
{
	return clients_.empty();
}

void Catalog::update(const Client& client)
{
	const auto it = find_if(clients_.begin(), clients_.end(), [&client](const Client& other)
	{
		return other.contract_id == client.contract_id;
	});
	if (it == clients_.end())
		throw std::invalid_argument("Абонент не найден в базе.");
	*it = client;
}

bool Catalog::remove(int id)
{
	const auto it = remove_if(clients_.begin(), clients_.end(),
	                          [&id](Client& other) { return id == other.contract_id; });
	const bool result = it != clients_.end();
	if (result)
		clients_.erase(it, clients_.end());
	return result;
}

container Catalog::linear_search(function<bool(const Client&)> predicate) const
{
	container result;
	for_each(clients_.begin(), clients_.end(), [&](const Client& other)
	{
		if (predicate(other)) result.emplace_back(other);
	});
	return result;
}

void Catalog::clear()
{
	clients_.clear();
}

int Catalog::size() const
{
	return clients_.size();
}

void Catalog::shrink(int size)
{
	if (size < 0)
		throw out_of_range("Недопустимое значение.");
	clients_.resize(size);
}

void Catalog::sort(bool predicate(const Client& client, const Client& other))
{
	std::sort(clients_.begin(), clients_.end(), predicate);
}

std::ostream& operator<<(std::ostream& out, const Catalog& catalog)
{
	ostream_iterator<Client> it(out);
	for_each(catalog.clients_.begin(), catalog.clients_.end(), [&it](const Client& client) { *it++ = client; });
	return out;
}

std::istream& operator>>(std::istream& in, Catalog& catalog)
{
	string tmp;
	getline(in, tmp);

	if (!in.eof())
	{
		istream_iterator<Client> it(in);
		istream_iterator<Client> eof_it;
		catalog.add(*it);
		while (it != eof_it)
			catalog.add(*++it);
	}

	return in;
}
