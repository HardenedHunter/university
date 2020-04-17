// ReSharper disable IdentifierTypo
// ReSharper disable CommentTypo

#pragma once
#include <string>
#include <vector>

using namespace std;

namespace vector_utils
{
	typedef unsigned uint;
	typedef int value_type;
	typedef vector<value_type> container;
	typedef vector<value_type>::iterator iter;
	typedef vector<value_type>::const_iterator const_iter;

	//Генерация случайного числа от -range до range
	int randint(uint range);

	//Заполнение файла случайными числами от -range до range
	void fill_file(const string& filename, uint count, uint range);

	//Заполнение файла из контейнера
	void fill_file(const string& filename, const container& source);

	//Заполнение контейнера из файла
	container fill_container(ifstream& in);

	//Заполнение контейнера из файла
	container fill_container(const string& filename);

	//Нахождение максимального элемента в контейнере
	value_type max(const_iter first, const const_iter& last);

	//Преобразование диапазона с помощью цикла
	container modify(const_iter first, const const_iter& last);

	//Преобразование контейнера с помощью цикла
	container modify(const container& source);

	//Преобразование контейнера с помощью std::transform
	container modify_transform(const container& source);

	//Преобразование контейнера с помощью std::for_each
	container modify_foreach(const container& source);

	//Нахождение суммы элементов контейнера
	int sum(const container& source);

	//Нахождение среднего арифметического элементов
	double average(const container& source);

	//Печать контейнера в консоль
	void print_container(container& source);
}
