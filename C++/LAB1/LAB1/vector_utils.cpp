// ReSharper disable StringLiteralTypo
// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
// ReSharper disable IdentifierTypo
#include "vector_utils.h"
#include <algorithm>
#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

namespace vector_utils
{
	int randint(const uint range)
	{
		const double fraction = 1.0 / (static_cast<double>(RAND_MAX) + 1.0);
		return static_cast<int>(rand() * fraction * (2 * range + 1) - range);
	}

	void fill_file(const string& filename, const uint count, const uint range)
	{
		ofstream out;
		out.open(filename, std::ofstream::out | std::ofstream::trunc);
		if (!out)
		{
			cout << "Не удалось открыть файл." << endl;
		}
		else
		{
			for (uint i = 0; i < count; ++i)
			{
				out << randint(range) << " ";
			}
		}
		out.close();
	}

	void fill_file(const string& filename, const container& source)
	{
		ofstream out;
		out.open(filename, std::ofstream::out | std::ofstream::trunc);
		if (!out)
		{
			cout << "Не удалось открыть файл." << endl;
		}
		else
		{
			for (const value_type& value : source)
			{
				out << value << " ";
			}
		}
		out.close();
	}

	container fill_container(ifstream& in)
	{
		value_type buffer;
		container result;
		while (!in.eof())
		{
			in >> buffer;
			result.emplace_back(buffer);
		}
		return result;
	}

	container fill_container(const string& filename)
	{
		ifstream in;
		in.open(filename);
		if (!in)
		{
			throw runtime_error("Не удалось открыть файл.");
		}
		container result = fill_container(in);
		in.close();
		return result;
	}

	value_type max(const_iter first, const const_iter& last)
	{
		if (first == last)
		{
			throw out_of_range("На вход подан пустой контейнер.");
		}

		value_type largest = *first;
		++first;
		for (; first != last; ++first)
		{
			if (largest < *first)
				largest = *first;
		}
		return largest;
	}

	container modify(const_iter first, const const_iter& last)
	{
		container result;
		if (first != last)
		{
			value_type max_elem = max(first, last);
			if (max_elem == 0)
			{
				result.assign(first, last);
			}
			else
			{
				max_elem = max_elem / 2 + max_elem % 2;
				for (; first != last; ++first)
				{
					result.emplace_back(*first / max_elem);
				}
			}
		}
		return result;
	}

	container modify(const container& source)
	{
		return modify(source.begin(), source.end());
	}

	container modify_transform(const container& source)
	{
		container result;
		if (!source.empty())
		{
			const const_iter first = source.begin();
			const const_iter last = source.end();
			value_type max_elem = max(first, last);
			if (max_elem == 0)
			{
				result.assign(first, last);
			}
			else
			{
				result.resize(source.size());
				max_elem = max_elem / 2 + max_elem % 2;
				std::transform(first, last, result.begin(), [max_elem](const value_type& elem)
				{
					return elem / max_elem;
				});
			}
		}
		return result;
	}

	container modify_foreach(const container& source)
	{
		container result;
		if (!source.empty())
		{
			const const_iter first = source.begin();
			const const_iter last = source.end();
			value_type max_elem = max(first, last);
			if (max_elem == 0)
			{
				result.assign(first, last);
			}
			else
			{
				max_elem = max_elem / 2 + max_elem % 2;
				std::for_each(first, last, [max_elem, &result](const value_type& elem)
				{
					result.emplace_back(elem / max_elem);
				});
			}
		}
		return result;
	}

	int sum(const container& source)
	{
		value_type sum = 0;
		for (const value_type& elem : source)
		{
			sum += elem;
		}
		return sum;
	}

	double average(const container& source)
	{
		if (source.empty())
			return 0;
		return static_cast<float>(sum(source)) / source.size();
	}

	void print_container(container& source)
	{
		for (value_type& value : source)
		{
			cout << value << " ";
		}
		cout << endl;
	}
}
