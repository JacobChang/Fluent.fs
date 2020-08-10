module rec Fluent.Syntax.Ast

type Identifier = { name: string }

type NamedArgument =
    { identifier: Identifier
      value: InlineExpression }

type CallArguments =
    { positional: InlineExpression array
      named: NamedArgument array }

type FunctionReference =
    { id: Identifier
      argumetns: CallArguments option }

type MessageReference =
    { id: Identifier
      attribute: Attribute option }

type TermReference =
    { id: Identifier
      attribute: Attribute option
      argumetns: CallArguments option }

type InlineExpression =
    | NumberLiteral of string
    | StringLiteral of string
    | FunctionReference of FunctionReference
    | MessageReference of MessageReference
    | TermReference of TermReference

type SelectExpression =
    { name: Identifier
      variants: Variant array }

type Expression =
    | InlineExpression of InlineExpression
    | SelectExpression of SelectExpression

type PatternElement =
    | Text of string
    | Placeable of Expression

type Pattern = PatternElement array

type Attribute =
    { identifier: Identifier
      value: Pattern }

type VariantKey =
    | NumberLiteral of string
    | Identifier of string

type Variant = { key: VariantKey; value: Pattern }

type Comment = { value: string array }

type Term =
    { identifier: Identifier
      value: Pattern
      attribute: Attribute array
      comment: Comment }

type Message =
    { identifier: Identifier
      value: Pattern
      attribute: Attribute array
      comment: Comment }

type Entry =
    | Message of Message
    | Term of Term
    | Comment of Comment

type Junk = Content of string

type Resource =
    | Entry of Entry
    | BlankBlock
    | Junk of Junk
