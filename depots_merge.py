import configparser

def read_ini_without_duplicates(ini_path):
    config = configparser.ConfigParser()
    with open(ini_path, 'r', encoding='utf-8') as ini_file:
        section = None
        seen_keys = set()  
        for line in ini_file:
            line = line.strip()
            if not line or line.startswith(';') or line.startswith('#'):
                continue  
            if line.startswith('[') and line.endswith(']'):
                section = line[1:-1].strip()
                seen_keys = set()  
                config.add_section(section)
            else:
                try:
                    key, value = line.split('=', 1)
                    key = key.strip()
                    value = value.strip()
                    if key not in seen_keys:
                        config.set(section, key, value)
                        seen_keys.add(key)
                except ValueError:
                    continue 
    return config

def merge_ini_files(main_ini_path, new_ini_path, output_ini_path):
    main_config = configparser.ConfigParser()
    with open(main_ini_path, 'r', encoding='utf-8') as main_file:
        main_config.read_file(main_file)
    new_config = read_ini_without_duplicates(new_ini_path)
    main_items = {}
    for section in main_config.sections():
        for key, value in main_config.items(section):
            main_items[int(key)] = value
    new_items = {}
    for section in new_config.sections():
        for key, value in new_config.items(section):
            new_items[int(key)] = value
    for key, value in new_items.items():
        if key not in main_items and value != "Unknown":
            main_items[key] = value
    sorted_items = sorted(main_items.items())
    with open(output_ini_path, 'w', encoding='utf-8') as output_ini_file:
        for key, value in sorted_items:
            output_ini_file.write(f'{key} = {value}\n')
    print(f'The merged INI file is saved as {output_ini_path}')

main_ini = 'depots.ini'
new_ini = 'new.ini'
output_ini = 'depots_new.ini'
merge_ini_files(main_ini, new_ini, output_ini)