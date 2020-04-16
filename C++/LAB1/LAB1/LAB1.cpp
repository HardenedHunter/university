// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable CppClangTidyClangDiagnosticSignCompare
// ReSharper disable CommentTypo
// ReSharper disable CppClangTidyHicppUseAuto
// ReSharper disable CppUseAuto
#include <clocale>
#include <ctime>
#include "console_utils.h"

using namespace std;
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
