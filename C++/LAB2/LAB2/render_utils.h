// ReSharper disable StringLiteralTypo
// ReSharper disable CppClangTidyClangDiagnosticInvalidSourceEncoding
#pragma once

#include "catalog.h"
#include "client.h"

using namespace business_logic;

namespace render_utils
{
	int render_menu();

	int render_search_menu();

	void render();

	void render_search(const Catalog<Client>& catalog);

	void render_print(const Catalog<Client>& catalog);

	void render_add(Catalog<Client>& c);

	void render_update(Catalog<Client>& catalog);

	void render_remove(Catalog<Client>& catalog);

	void render_clear(Catalog<Client>& catalog);

	void render_add_from_file(Catalog<Client>& catalog);

	void render_save_to_file(Catalog<Client>& catalog);
}
