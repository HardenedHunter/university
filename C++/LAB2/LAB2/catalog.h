#pragma once
#include <functional>
#include <vector>


#include "client.h"

using namespace business_logic;

class Catalog
{
private:
	vector<Client> clients_;
public:
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
	vector<Client> binary_search(function<bool(const Client&)> predicate) const;
	vector<Client> linear_search(function<bool(const Client&)> predicate) const;

	friend std::ostream& operator<<(std::ostream& out, const Catalog& catalog);
	friend std::istream& operator>>(std::istream& in, Catalog& catalog);
};
