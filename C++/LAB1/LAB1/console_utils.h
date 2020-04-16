#pragma once
#include <string>
#include "vector_utils.h"

using namespace std;
using namespace vector_utils;

namespace console_utils
{
	bool is_correct_filename(const string& filename);

	string input_filename(const string& message);

	int input_number(const string& message, int min, int max);
	
	int render_menu();

	void render_fill_file();

	void render_fill_container(container& target);

	void render_modify(container& source, container modifier(const container&));

	void render_sum(container& source);

	void render_average(container& source);

	void render_console_print(container& source);

	void render_file_print(container& source);

	void render();
}