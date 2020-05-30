// ReSharper disable StringLiteralTypo
#include <clocale>
#include <cstdlib>
#include <ctime>
#include "console_utils.h"

#include "render_utils.h"

using namespace render_utils;
using namespace console_utils;

void setup()
{
	setlocale(LC_ALL, "Russian");
	srand(time(nullptr));
	rand();
}

int main()
{
	setup();
	render();
}
