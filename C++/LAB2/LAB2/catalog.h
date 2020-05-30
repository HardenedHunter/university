#pragma once
#include <functional>
#include <vector>
#include "client.h"
#include <algorithm>

using namespace business_logic;

typedef vector<Client> container;

class Catalog
{
private:
	container clients_;
	int version_;
public:
	Catalog();
	explicit Catalog(container clients);

	int get_version() const;
	void reset_version();
	bool add(const Client& client);
	void print() const;
	bool contains(int id) const;
	bool empty() const;
	void update(const Client& client);
	bool remove(int id);
	void clear();
	int size() const;
	void shrink(int size);
	void sort(bool predicate(const Client& client, const Client& other));

	template <typename E>
	container binary_search(const E& field, function<E(const Client&)> get_field) const;

	container linear_search(function<bool(const Client&)> predicate) const;

	friend std::ostream& operator<<(std::ostream& out, const Catalog& catalog);
	friend std::istream& operator>>(std::istream& in, Catalog& catalog);
};

template <typename E>
container Catalog::binary_search(const E& field, function<E(const Client&)> get_field) const
{
	container result;
	const auto low = lower_bound(clients_.begin(), clients_.end(), field,
	                             [&](const Client& item, const E& f) { return compare(get_field(item), f) < 0; });
	const auto up = upper_bound(clients_.begin(), clients_.end(), field,
	                            [&](const E& f, const Client& item) { return compare(f, get_field(item)) < 0; });
	for_each(low, up, [&result](const Client& client) { result.emplace_back(client); });

	return result;
}
