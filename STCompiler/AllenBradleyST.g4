grammar AllenBradleyST;

/*
 * Parser Rules
 */

testBatTop: block+;

arithmaticOperator: Plus | Minus | Mul | Div | Mod;

arithmaticCompare:
	Less
	| LessEqual
	| Greater
	| GreaterEqual
	| Equal
	| NotEqual;

booleanCompare: Or | And | Xor;

compilationUnit: identifier EOF?;

string: String;

identifier:
	ID
	| DigitSequence
	| '16#' DigitSequence
	| '16#' ID
	| identifier ('.') (identifier | indexOperator)
	| identifier indexOperator;

negative: Minus;

indexOperator: BracketOpen expression BracketClose;

nestedParenthesesBlock: (
		~('(' | ')')
		| '(' nestedParenthesesBlock ')'
	)*;

nestedExpression: '(' expression ')';

allOperator:
	arithmaticOperator
	| booleanCompare
	| arithmaticCompare;

function: identifier '(' functionArg* ')';

functionArg: expression ','?;

primaryExpression: expression;

expression:
	identifier
	| '(' expression ')'
	| (Not | negative) expression
	| expression arithmaticOperator expression
	| expression arithmaticCompare expression
	| expression booleanCompare expression
	| function;

assignment: identifier Assign (primaryExpression | string);

statement:
	assignment Semi
	| function Semi
	| exitStatement
	| Semi;

block: ((conditional)+ | statement+ | loop+)+;

conditionalScopeEnd: ConditionalScopeEnd Semi;

loopScopeEnd: LoopScopeEnd Semi;

caseScopeEnd: CaseScopeEnd Semi;

conditional:
	ifStatement elseIfStatement* elseStatement? conditionalScopeEnd
	| caseStatement caseBlock* caseElseStatement? caseScopeEnd;

ifStatement: If primaryExpression Then block?;

elseIfStatement: Elsif primaryExpression Then block?;

elseStatement: Else block?;

caseElseStatement: Else block?;

caseStatement: Case identifier Of;

caseIdentifier: DigitSequence | (DigitSequence ',');

caseBlock: caseIdentifier+ ':' block;

exitStatement: Exit Semi;

loop:
	forLoop block? loopScopeEnd
	| Repeat block? repeatLoop loopScopeEnd;

forLoop: For assignment To expression (By expression)? Do;

repeatLoop: Until primaryExpression;

/*
 * Lexer Rules
 */

ConditionalScopeEnd: EndIf;

LoopScopeEnd: EndFor | EndRepeat | EndWhile;

CaseScopeEnd: EndCase;

COMMENT: '(*' .*? '*)' -> skip;

LINE_COMMENT: '//' ~[\r\n]* -> skip;

Plus: '+';
Minus: '-';
Mul: '*';
Div: '/';
Less: '<';
LessEqual: '<=';
Greater: '>';
GreaterEqual: '>=';
Equal: '=';
NotEqual: '<>';
StringQuote: '\'';

Assign: ':=';

Semi: ';';
BracketOpen: '[';
BracketClose: ']';

fragment A: [aA]; // match either an 'a' or 'A'
fragment B: [bB];
fragment C: [cC];
fragment D: [dD];
fragment E: [eE];
fragment F: [fF];
fragment G: [gG];
fragment H: [hH];
fragment I: [iI];
fragment J: [jJ];
fragment K: [kK];
fragment L: [lL];
fragment M: [mM];
fragment N: [nN];
fragment O: [oO];
fragment P: [pP];
fragment Q: [qQ];
fragment R: [rR];
fragment S: [sS];
fragment T: [tT];
fragment U: [uU];
fragment V: [vV];
fragment W: [wW];
fragment X: [xX];
fragment Y: [yY];
fragment Z: [zZ];

fragment Letter:
	A
	| B
	| C
	| D
	| E
	| F
	| G
	| H
	| I
	| J
	| K
	| L
	| M
	| N
	| O
	| P
	| Q
	| R
	| S
	| T
	| U
	| V
	| W
	| X
	| Y
	| Z
	| '_';

If: I F;
Else: E L S E;
For: F O R;
While: W H I L E;
Do: D O;
By: B Y;
To: T O;
Elsif: E L S I F;
Then: T H E N;
Until: U N T I L;
Repeat: R E P E A T;
Exit: E X I T;
Case: C A S E;
EndIf: E N D '_' I F;
EndWhile: E N D '_' W H I L E;
EndFor: E N D '_' F O R;
EndCase: E N D '_' C A S E;
EndRepeat: E N D '_' R E P E A T;
Of: O F;
Mod: M O D;

And: A N D;
Or: O R;
Not: N O T;
Xor: X O R;

DigitSequence: Digit+;

fragment Digit: [0-9];

String: StringQuote '~($\')'* StringQuote;

ID: Letter (Letter | Digit)*;

UnderScores: [_]+ -> skip;

WS: [ \t\r\n]+ -> skip;

