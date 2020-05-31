// ReSharper disable StringLiteralTypo
// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding

#pragma once
#include <functional>
#include <vector>
#include <algorithm>
#include "catalog.h"
#include <iostream>
#include <iterator>
#include <utility>
#include "client.h"

using namespace std;
using namespace business_logic;

template <typename T>
class Catalog
{
private:
	vector<T> items_;
	int version_;
public:
	Catalog();
	explicit Catalog(vector<T> items);

	int get_version() const;
	void reset_version();
	bool add(const T& item);
	void print() const;
	bool contains(int id) const;
	bool empty() const;
	void update(const T& item);
	bool remove(int id);
	void clear();
	int size() const;
	void shrink(int size);
	void sort(bool predicate(const T& lvalue, const T& rvalue));

	template <typename E>
	vector<T> binary_search(const E& field, function<E(const T&)> get_field) const;

	vector<T> linear_search(function<bool(const T&)> predicate) const;

	friend ostream& operator<<(std::ostream& out, const Catalog<T>& catalog)
	{
		ostream_iterator<T> it(out);
		for_each(catalog.items_.begin(), catalog.items_.end(), [&it](const T& item) { *it++ = item; });
		return out;
	}

	friend istream& operator>>(std::istream& in, Catalog<T>& catalog)
	{
		string tmp;
		getline(in, tmp);

		if (!in.eof())
		{
			istream_iterator<T> it(in);
			istream_iterator<T> eof_it;
			catalog.add(*it);
			while (it != eof_it)
				catalog.add(*++it);
		}

		return in;
	}
};

template <typename T>
Catalog<T>::Catalog()
{
	items_ = vector<T>();
	version_ = 0;
}

template <typename T>
Catalog<T>::Catalog(vector<T> items)
{
	items_ = std::move(items);
	version_ = 0;
}

template <typename T>
int Catalog<T>::get_version() const
{
	return version_;
}

template <typename T>
void Catalog<T>::reset_version()
{
	version_ = 0;
}

template <typename T>
bool Catalog<T>::add(const T& item)
{
	const bool result = !contains(item.contract_id);
	if (!result)
		cout << "Запись с номером контракта " << item.contract_id << " уже есть в базе." << endl;
	else
	{
		items_.emplace_back(item);
		version_++;
	}
	return result;
}

template <typename T>
void Catalog<T>::print() const
{
	if (items_.empty())
		cout << "Справочник пуст." << endl;
	else
		for (const T& value : items_)
			cout << value << endl;
	cout << endl;
}

template <typename T>
bool Catalog<T>::contains(const int id) const
{
	return any_of(items_.begin(), items_.end(), [&id](const T& other)
	{
		return (id == other.contract_id);
	});
}

template <typename T>
bool Catalog<T>::empty() const
{
	return items_.empty();
}

template <typename T>
void Catalog<T>::update(const T& item)
{
	const auto it = find_if(items_.begin(), items_.end(), [&item](const T& other)
	{
		return other.contract_id == item.contract_id;
	});
	if (it == items_.end())
		throw std::invalid_argument("Запись не найдена в базе.");
	*it = item;
	version_++;
}

template <typename T>
bool Catalog<T>::remove(int id)
{
	const auto it = remove_if(items_.begin(), items_.end(),
	                          [&id](T& other) { return id == other.contract_id; });
	const bool result = it != items_.end();
	if (result)
	{
		items_.erase(it, items_.end());
		version_++;
	}
	return result;
}

template <typename T>
vector<T> Catalog<T>::linear_search(function<bool(const T&)> predicate) const
{
	vector<T> result;
	for_each(items_.begin(), items_.end(), [&](const T& other)
	{
		if (predicate(other)) result.emplace_back(other);
	});
	return result;
}

template <typename T>
void Catalog<T>::clear()
{
	items_.clear();
	version_++;
}

template <typename T>
int Catalog<T>::size() const
{
	return items_.size();
}

template <typename T>
void Catalog<T>::shrink(int size)
{
	if (size < 0)
		throw out_of_range("Недопустимое значение.");
	items_.resize(size);
	version_++;
}

template <typename T>
void Catalog<T>::sort(bool predicate(const T& lvalue, const T& rvalue))
{
	std::sort(items_.begin(), items_.end(), predicate);
}

template <typename T>
template <typename E>
vector<T> Catalog<T>::binary_search(const E& field, function<E(const T&)> get_field) const
{
	vector<T> result;
	const auto low = lower_bound(items_.begin(), items_.end(), field,
	                             [&](const T& item, const E& f) { return compare(get_field(item), f) < 0; });
	const auto up = upper_bound(items_.begin(), items_.end(), field,
	                            [&](const E& f, const T& item) { return compare(f, get_field(item)) < 0; });
	for_each(low, up, [&result](const T& item) { result.emplace_back(item); });

	return result;
}
