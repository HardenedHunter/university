// ReSharper disable StringLiteralTypo
// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
#pragma once

#include "catalog.h"

namespace render_utils
{
	int render_menu();

	int render_search_menu();

	void render();

	void render_search(const Catalog& catalog);

	void render_print(const Catalog& catalog);

	void render_add(Catalog& c);

	void render_update(Catalog& catalog);

	void render_remove(Catalog& catalog);

	void render_clear(Catalog& catalog);

	void render_add_from_file(Catalog& catalog);

	void render_save_to_file(Catalog& catalog);
}
