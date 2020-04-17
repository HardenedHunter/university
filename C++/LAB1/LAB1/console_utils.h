// ReSharper disable CommentTypo

#pragma once
#include <string>
#include "vector_utils.h"

using namespace std;
using namespace vector_utils;

namespace console_utils
{
	//Проверка имени файла на корректность
	bool is_correct_filename(const string& filename);

	//Ввод имени файла
	string input_filename(const string& message);

	//Ввод числа в заданном диапазоне
	int input_number(const string& message, int min, int max);

	//Вывод меню
	int render_menu();

	//Функции-обёртки для управления программой через консоль
	
	//Консольный интерфейс для заполнения файла числами
	void render_fill_file();

	//Консольный интерфейс для заполнения контейнера
	void render_fill_container(container& target);

	//Консольный интерфейс для изменения контейнера
	void render_modify(container& source, container modifier(const container&));

	//Консольный интерфейс для подсчёта суммы элементов контейнера
	void render_sum(container& source);

	//Консольный интерфейс для подсчёта среднего арифметического элементов контейнера
	void render_average(container& source);

	//Консольный интерфейс для вывода контейнера на экран
	void render_console_print(container& source);

	//Консольный интерфейс для вывода контейнера в файл
	void render_file_print(container& source);

	//Основная функция для отрисовки интерфейса
	void render();
}