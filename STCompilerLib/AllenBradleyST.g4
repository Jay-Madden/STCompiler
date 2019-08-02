grammar AllenBradleyST;

/*
 * Parser Rules
 */


compilationUnit: block+ EOF?;

arithmaticOperator: Plus | Minus | Mul | Div | Mod;

arithmaticCompare:
	Less
	| LessEqual
	| Greater
	| GreaterEqual
	| Equal
	| NotEqual;

booleanCompare: Or | And | Xor;

string: String;

booleanIdentifier: True | False;

identifier:
	ID
	| booleanIdentifier
	| DigitSequence
	| '16#' DigitSequence
	| '16#' ID
	| identifier ('.') (identifier | indexOperator)
	| identifier indexOperator;

negative: Minus;

indexOperator: BracketOpen expression BracketClose;

function: identifier '(' functionArg* ')';

functionArg: expression ','?;

primaryExpression: expression;
expression:
	identifier #identifierExpression
	| '(' expression ')' #subExpression
	| (Not | negative) expression #negationExpression
	| expression arithmaticOperator expression #arithmaticMathExpression
	| expression arithmaticCompare expression  #arithmaticCompareExpression
	| expression booleanCompare expression	   #booleanCompareExpression
	| function #functionExpression;
/* 
expression:
	 arithmaticMathExpression #topLevelMathExpression
	| booleanExpression #topLevelBoolExpression
	;

booleanExpression:
	identifier
	| '(' booleanExpression ')'
	| Not booleanExpression
	| booleanExpression arithmaticCompare booleanExpression
	| booleanExpression booleanCompare booleanExpression;

arithmaticMathExpression:
	identifier
	| '(' arithmaticMathExpression ')'
	| (Not | negative) arithmaticMathExpression
	| arithmaticMathExpression arithmaticOperator arithmaticMathExpression ;
*/
/*
arithmaticCompareExpression:
	booleanExpression

booleanCompareExpression:
	booleanExpression
	| booleanCompareExpression booleanCompare booleanCompareExpression;
*/

assignment: identifier Assign (primaryExpression | string);

statement:
	assignment Semi
	| function Semi
	| exitStatement
	| Semi;

block: ((conditional)+ | statement+ | loopBlock+)+;

conditionalScopeEnd: ConditionalScopeEnd Semi;

loopScopeEnd: LoopScopeEnd Semi;

caseScopeEnd: CaseScopeEnd Semi;

conditional:
	ifBlock elseIfBlock* elseBlock? conditionalScopeEnd
	| caseStatement caseBlock* caseElseStatement? caseScopeEnd;

ifStatement: If primaryExpression Then;

ifBlock: ifStatement block?;

elseIfStatement: Elsif primaryExpression Then;

elseIfBlock: elseIfStatement block?;

elseBlock: Else block?;

caseElseStatement: Else block?;

caseStatement: Case identifier Of;

caseIdentifier: DigitSequence | (DigitSequence ',');

caseBlock: caseIdentifier+ ':' block;

exitStatement: Exit Semi;

loopBlock:
	forLoop block? loopScopeEnd #forLoopBlock
	| Repeat block? repeatLoop loopScopeEnd #repeatLoopBlock
	;

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
False: F A L S E;
True: T R U E;

DigitSequence: Digit+;

fragment Digit: [0-9];

String: StringQuote '~($\')'* StringQuote;

ID: Letter (Letter | Digit)*;

UnderScores: [_]+ -> skip;

WS: [ \t\r\n]+ -> skip;

