# console-command-generator
Console command generator provides backend for console command generation. Application has suggestion, validation, auto complation properties and also user can put event handler to any part of the command. Command generater can take arguments that repeats and gives suggestions.  user can synamically provide console commands and parameters

## Properties

### Advisor
Advisor helps user for auto complation of command. User can enter just a part of the command and can send this part to advisor. Advisor detects the command and suggests possible command strings.

### Validator
Validity of command or part of command is tested by this method.

### Splitter
Splits commands according to spaces.

### Handler
User can add handler at any space separeted part of the command and on demand actions can be taken

### Executor
Validates and executes handler of the command

### Manager
Manager stores command sets


