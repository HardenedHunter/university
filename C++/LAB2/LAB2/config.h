#pragma once
#include <string>
#include "console_utils.h"
#include "catalog.h"

using namespace std;
using namespace console_utils;

const string config_filename = "config.txt";
const string db_filename = "db.txt";

struct Config
{
	string filename;
	Catalog load();
	void save(const Catalog& catalog) const;
	void create_config_file() const;
};

istream& operator>>(istream& in, Config& config);
ostream& operator<<(ostream& out, const Config& config);
