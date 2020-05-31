#pragma once
#include <string>
#include "console_utils.h"
#include "catalog.h"
#include "client.h"

using namespace std;
using namespace console_utils;
using namespace business_logic;

const string config_filename = "config.txt";
const string db_filename = "db.txt";

struct Config
{
	string filename;
	Catalog<Client> load();
	void save(const Catalog<Client>& catalog) const;
	void create_config_file() const;
};

istream& operator>>(istream& in, Config& config);
ostream& operator<<(ostream& out, const Config& config);
