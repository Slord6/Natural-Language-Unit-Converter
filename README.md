# Natural Language Unit Converter
 Natural langage input, conversion output

A unit converter on the command line which uses plain English as input

## Usage

`.\NLUC.exe "12 m/s in cm/min"`

`.\NLUC.exe "12 Mb in GB"`

`.\NLUC.exe "5m/day in mi/yr"`

`.\NLUC.exe "5 pennies in pounds"`

`.\NLUC.exe "20 kg in pounds"`

`.\NLUC.exe "2m in ft and inches"`

`.\NLUC.exe "15.55 days in hours and mins"`

or just run `.\NLUC.exe` for a REPL-like environement

You can also use it in pipes in powershell:

`.\NLUC.exe 200lb in kg | foreach {Write-Output "$_ =" ;.\NLUC.exe "$_ in g"}`

### References

You can also see 'reference' values:

`.\NLUC.exe "1200kg as elephants"`
`.\NLUC.exe "3.4km as empire state buildings"`
`.\NLUC.exe "44F ref chickens"`

References can have multiple values, each related to a base SI unit, eg. Elephant has mass height.

For a list of all available units and references, pass `?` as the query


## TODO

Support queries like:

- `15l/s in kg/min where 2 litres = 1.2 kilograms` / `15l/s in kg/min where 2 litres is 1.2 kilograms`
- Volumes/areas
- `2 cups of water in kg`
- `2km in steps where 1 step is 30cm` - 'steps' may or may not be defined already
- `1 oz as gold` - output `x moles`
- `<measurement>` - output `a measure of <base measurement>`, eg `km` -> `a measure of metres`
- `15.55 days in hours, mins and seconds` or `15.55 days in hours and mins and seconds` or `15.55 days in hours mins seconds`