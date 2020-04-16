// ReSharper disable IdentifierTypo
#pragma once
#include <string>
#include <vector>

using namespace std;

namespace vector_utils
{
	typedef unsigned uint;
	typedef int value_type;
	typedef vector<value_type> container;
	typedef vector<int>::iterator iter;
	typedef vector<int>::const_iterator const_iter;
	
	int randint(uint range);

	void fill_file(const string& filename, uint count, uint range);

	void fill_file(const string& filename, const container& source);
	
	container fill_container(ifstream& in);

	container fill_container(const string& filename);

	value_type max(const_iter first, const const_iter& last);

	container modify(const_iter first, const const_iter& last);

	container modify(const container& source);

	container modify_transform(const container& source);

	container modify_foreach(const container& source);

	int sum(const container& source);
	
	double average(const container& source);

	void print_container(container& source);
}
