/**
 * Globalize v1.0.1
 *
 * http://github.com/jquery/globalize
 *
 * Copyright jQuery Foundation and other contributors
 * Released under the MIT license
 * http://jquery.org/license
 *
 * Date: 2016-01-20T16:57Z
 */
/*!
 * Globalize v1.0.1 2016-01-20T16:57Z Released under the MIT license
 * http://git.io/TrdQbw
 */
(function(root, factory) {

    // UMD returnExports
    if (typeof define === "function" && define.amd) {

        // AMD
        define([
                "cldr",
                "../globalize",
                "cldr/event"
            ],
            factory);
    } else if (typeof exports === "object") {

        // Node, CommonJS
        module.exports = factory(require("cldrjs"), require("globalize"));
    } else {

        // Extend global
        factory(root.Cldr, root.Globalize);
    }
}(this,
    function(Cldr, Globalize) {

        var alwaysArray = Globalize._alwaysArray,
            isPlainObject = Globalize._isPlainObject,
            validate = Globalize._validate,
            validateDefaultLocale = Globalize._validateDefaultLocale,
            validateParameterPresence = Globalize._validateParameterPresence,
            validateParameterType = Globalize._validateParameterType,
            validateParameterTypePlainObject = Globalize._validateParameterTypePlainObject;
/**
 * messageformat.js
 *
 * ICU PluralFormat + SelectFormat for JavaScript
 * 
 * Copyright 2014
 * 
 * Licensed under the MIT License
 *
 * @author Alex Sexton - @SlexAxton
 * @version 0.2.1
 * @contributor_license Dojo CLA
 */

        var MessageFormat;
/* jshint ignore:start */
        MessageFormat = (function() {

            function MessageFormat(locale, pluralFunc, formatters) {
                if (!locale) {
                    this.lc = ["en"];
                } else if (typeof locale == "string") {
                    this.lc = [];
                    for (var l = locale; l; l = l.replace(/[-_]?[^-_]*$/, "")) this.lc.push(l);
                } else {
                    this.lc = locale;
                }

                this.runtime.pf = {};
                this.runtime.pf[this.lc[0]] = pluralFunc;
                this.runtime.fmt = {};
                if (formatters)
                    for (var f in formatters) {
                        this.runtime.fmt[f] = formatters[f];
                    }
            }

            if (!("plurals" in MessageFormat)) MessageFormat.plurals = {};


            // note: Intl is not defined in default Node until joyent/node#7676 lands
            MessageFormat.formatters = {
                number: function(self) {
                    return new Function("v,lc,p",
                        "return Intl.NumberFormat(lc,\n" +
                        "    p=='integer' ? {maximumFractionDigits:0}\n" +
                        "  : p=='percent' ? {style:'percent'}\n" +
                        "  : p=='currency' ? {style:'currency', currency:'" +
                        (self.currency || "USD") +
                        "', minimumFractionDigits:2, maximumFractionDigits:2}\n" +
                        "  : {}).format(v)"
                    );
                },
                date: function(v, lc, p) {
                    var o = { day: "numeric", month: "short", year: "numeric" };
                    switch (p) {
                    case "full":
                        o.weekday = "long";
                    case "long":
                        o.month = "long";
                        break;
                    case "short":
                        o.month = "numeric";
                    }
                    return (new Date(v)).toLocaleDateString(lc, o);
                },
                time: function(v, lc, p) {
                    var o = { second: "numeric", minute: "numeric", hour: "numeric" };
                    switch (p) {
                    case "full":
                    case "long":
                        o.timeZoneName = "short";
                        break;
                    case "short":
                        delete o.minute;
                    }
                    return (new Date(v)).toLocaleTimeString(lc, o);
                }
            };

            MessageFormat.prototype.setIntlSupport = function(enable) {
                this.withIntlSupport = !!enable || (typeof enable == "undefined");
                return this;
            };

            MessageFormat.prototype.runtime = {
                _n: function(v, o) {
                    if (isNaN(v)) throw new Error("'" + v + "' isn't a number.");
                    return v - (o || 0)
                },
                _p: function(v, o, l, p, s) { return v in p ? p[v] : (v = l(v - o, s), v in p ? p[v] : p.other) },
                _s: function(v, p) { return v in p ? p[v] : p.other },
                pf: {},
                fmt: {},
                toString: function() {
                    var _stringify = function(o, top) {
                        if (typeof o != "object") return o.toString().replace(/^(function) \w*/, "$1");
                        var s = [];
                        for (var i in o)
                            if (i != "toString") {
                                s.push((top ? i + "=" : JSON.stringify(i) + ":") + _stringify(o[i], false));
                            }
                        return top ? s.join(",\n") : "{" + s.join(",\n") + "}";
                    };
                    return _stringify(this, true);
                }
            };

            // This is generated and pulled in for browsers.
            var mparser = (function() {
                /*
                 * Generated by PEG.js 0.8.0.
                 *
                 * http://pegjs.majda.cz/
                 */

                function peg$subclass(child, parent) {
                    function ctor() { this.constructor = child; }

                    ctor.prototype = parent.prototype;
                    child.prototype = new ctor();
                }

                function SyntaxError(message, expected, found, offset, line, column) {
                    this.message = message;
                    this.expected = expected;
                    this.found = found;
                    this.offset = offset;
                    this.line = line;
                    this.column = column;

                    this.name = "SyntaxError";
                }

                peg$subclass(SyntaxError, Error);

                function parse(input) {
                    var options = arguments.length > 1 ? arguments[1] : {},

                        peg$FAILED = {},

                        peg$startRuleFunctions = { start: peg$parsestart },
                        peg$startRuleFunction = peg$parsestart,

                        peg$c0 = function(messageFormatPattern) {
                            return { type: "program", program: messageFormatPattern };
                        },
                        peg$c1 = peg$FAILED,
                        peg$c2 = [],
                        peg$c3 = function(s1, inner) {
                            var st = [];
                            if (s1 && s1.val) {
                                st.push(s1);
                            }
                            for (var i in inner) {
                                if (inner.hasOwnProperty(i)) {
                                    st.push(inner[i]);
                                }
                            }
                            return { type: "messageFormatPattern", statements: st };
                        },
                        peg$c4 = "{",
                        peg$c5 = { type: "literal", value: "{", description: "\"{\"" },
                        peg$c6 = "}",
                        peg$c7 = { type: "literal", value: "}", description: "\"}\"" },
                        peg$c8 = function(mfe, s1) {
                            var res = [];
                            if (mfe) {
                                res.push(mfe);
                            }
                            if (s1 && s1.val) {
                                res.push(s1);
                            }
                            return { type: "messageFormatPatternRight", statements: res };
                        },
                        peg$c9 = null,
                        peg$c10 = ",",
                        peg$c11 = { type: "literal", value: ",", description: "\",\"" },
                        peg$c12 = function(argIdx, efmt) {
                            var res = {
                                type: "messageFormatElement",
                                argumentIndex: argIdx
                            };
                            if (efmt && efmt.length) {
                                res.elementFormat = efmt[1];
                            } else {
                                res.output = true;
                            }
                            return res;
                        },
                        peg$c13 = "plural",
                        peg$c14 = { type: "literal", value: "plural", description: "\"plural\"" },
                        peg$c15 = function(t, s) {
                            return {
                                type: "elementFormat",
                                key: t,
                                val: s.val
                            };
                        },
                        peg$c16 = "selectordinal",
                        peg$c17 = { type: "literal", value: "selectordinal", description: "\"selectordinal\"" },
                        peg$c18 = "select",
                        peg$c19 = { type: "literal", value: "select", description: "\"select\"" },
                        peg$c20 = function(t, p) {
                            return {
                                type: "elementFormat",
                                key: t,
                                val: p
                            };
                        },
                        peg$c21 = function(pfp) {
                            return { type: "pluralStyle", val: pfp };
                        },
                        peg$c22 = function(sfp) {
                            return { type: "selectStyle", val: sfp };
                        },
                        peg$c23 = function(op, pf) {
                            var res = {
                                type: "pluralFormatPattern",
                                pluralForms: pf
                            };
                            if (op) {
                                res.offset = op;
                            } else {
                                res.offset = 0;
                            }
                            return res;
                        },
                        peg$c24 = "offset",
                        peg$c25 = { type: "literal", value: "offset", description: "\"offset\"" },
                        peg$c26 = ":",
                        peg$c27 = { type: "literal", value: ":", description: "\":\"" },
                        peg$c28 = function(d) {
                            return d;
                        },
                        peg$c29 = function(pf) {
                            return {
                                type: "selectFormatPattern",
                                pluralForms: pf
                            };
                        },
                        peg$c30 = function(k, mfp) {
                            return {
                                type: "pluralForms",
                                key: k,
                                val: mfp
                            };
                        },
                        peg$c31 = function(i) {
                            return i;
                        },
                        peg$c32 = "=",
                        peg$c33 = { type: "literal", value: "=", description: "\"=\"" },
                        peg$c34 = function(p) {
                            return p;
                        },
                        peg$c35 = function(ws, s) {
                            var tmp = [];
                            for (var i = 0; i < s.length; ++i) {
                                for (var j = 0; j < s[i].length; ++j) {
                                    tmp.push(s[i][j]);
                                }
                            }
                            return {
                                type: "string",
                                val: ws + tmp.join("")
                            };
                        },
                        peg$c36 = /^[0-9a-zA-Z$_]/,
                        peg$c37 = { type: "class", value: "[0-9a-zA-Z$_]", description: "[0-9a-zA-Z$_]" },
                        peg$c38 = /^[^ \t\n\r,.+={}]/,
                        peg$c39 = { type: "class", value: "[^ \\t\\n\\r,.+={}]", description: "[^ \\t\\n\\r,.+={}]" },
                        peg$c40 = function(s1, s2) {
                            return s1 + (s2 ? s2.join("") : "");
                        },
                        peg$c41 = function(chars) { return chars.join(""); },
                        peg$c42 = /^[^{}\\\0-\x1F \t\n\r]/,
                        peg$c43 = {
                            type: "class",
                            value: "[^{}\\\\\\0-\\x1F \\t\\n\\r]",
                            description: "[^{}\\\\\\0-\\x1F \\t\\n\\r]"
                        },
                        peg$c44 = function(x) {
                            return x;
                        },
                        peg$c45 = "\\#",
                        peg$c46 = { type: "literal", value: "\\#", description: "\"\\\\#\"" },
                        peg$c47 = function() {
                            return "\\#";
                        },
                        peg$c48 = "\\{",
                        peg$c49 = { type: "literal", value: "\\{", description: "\"\\\\{\"" },
                        peg$c50 = function() {
                            return "\u007B";
                        },
                        peg$c51 = "\\}",
                        peg$c52 = { type: "literal", value: "\\}", description: "\"\\\\}\"" },
                        peg$c53 = function() {
                            return "\u007D";
                        },
                        peg$c54 = "\\u",
                        peg$c55 = { type: "literal", value: "\\u", description: "\"\\\\u\"" },
                        peg$c56 = function(h1, h2, h3, h4) {
                            return String.fromCharCode(parseInt("0x" + h1 + h2 + h3 + h4));
                        },
                        peg$c57 = /^[0-9]/,
                        peg$c58 = { type: "class", value: "[0-9]", description: "[0-9]" },
                        peg$c59 = function(ds) {
                            return parseInt((ds.join("")), 10);
                        },
                        peg$c60 = /^[0-9a-fA-F]/,
                        peg$c61 = { type: "class", value: "[0-9a-fA-F]", description: "[0-9a-fA-F]" },
                        peg$c62 = { type: "other", description: "whitespace" },
                        peg$c63 = function(w) { return w.join(""); },
                        peg$c64 = /^[ \t\n\r]/,
                        peg$c65 = { type: "class", value: "[ \\t\\n\\r]", description: "[ \\t\\n\\r]" },

                        peg$currPos = 0,
                        peg$reportedPos = 0,
                        peg$cachedPos = 0,
                        peg$cachedPosDetails = { line: 1, column: 1, seenCR: false },
                        peg$maxFailPos = 0,
                        peg$maxFailExpected = [],
                        peg$silentFails = 0,

                        peg$result;

                    if ("startRule" in options) {
                        if (!(options.startRule in peg$startRuleFunctions)) {
                            throw new Error("Can't start parsing from rule \"" + options.startRule + "\".");
                        }

                        peg$startRuleFunction = peg$startRuleFunctions[options.startRule];
                    }

                    function text() {
                        return input.substring(peg$reportedPos, peg$currPos);
                    }

                    function offset() {
                        return peg$reportedPos;
                    }

                    function line() {
                        return peg$computePosDetails(peg$reportedPos).line;
                    }

                    function column() {
                        return peg$computePosDetails(peg$reportedPos).column;
                    }

                    function expected(description) {
                        throw peg$buildException(
                            null,
                            [{ type: "other", description: description }],
                            peg$reportedPos
                        );
                    }

                    function error(message) {
                        throw peg$buildException(message, null, peg$reportedPos);
                    }

                    function peg$computePosDetails(pos) {
                        function advance(details, startPos, endPos) {
                            var p, ch;

                            for (p = startPos; p < endPos; p++) {
                                ch = input.charAt(p);
                                if (ch === "\n") {
                                    if (!details.seenCR) {
                                        details.line++;
                                    }
                                    details.column = 1;
                                    details.seenCR = false;
                                } else if (ch === "\r" || ch === "\u2028" || ch === "\u2029") {
                                    details.line++;
                                    details.column = 1;
                                    details.seenCR = true;
                                } else {
                                    details.column++;
                                    details.seenCR = false;
                                }
                            }
                        }

                        if (peg$cachedPos !== pos) {
                            if (peg$cachedPos > pos) {
                                peg$cachedPos = 0;
                                peg$cachedPosDetails = { line: 1, column: 1, seenCR: false };
                            }
                            advance(peg$cachedPosDetails, peg$cachedPos, pos);
                            peg$cachedPos = pos;
                        }

                        return peg$cachedPosDetails;
                    }

                    function peg$fail(expected) {
                        if (peg$currPos < peg$maxFailPos) {
                            return;
                        }

                        if (peg$currPos > peg$maxFailPos) {
                            peg$maxFailPos = peg$currPos;
                            peg$maxFailExpected = [];
                        }

                        peg$maxFailExpected.push(expected);
                    }

                    function peg$buildException(message, expected, pos) {
                        function cleanupExpected(expected) {
                            var i = 1;

                            expected.sort(function(a, b) {
                                if (a.description < b.description) {
                                    return -1;
                                } else if (a.description > b.description) {
                                    return 1;
                                } else {
                                    return 0;
                                }
                            });

                            while (i < expected.length) {
                                if (expected[i - 1] === expected[i]) {
                                    expected.splice(i, 1);
                                } else {
                                    i++;
                                }
                            }
                        }

                        function buildMessage(expected, found) {
                            function stringEscape(s) {
                                function hex(ch) { return ch.charCodeAt(0).toString(16).toUpperCase(); }

                                return s
                                    .replace(/\\/g, "\\\\")
                                    .replace(/"/g, '\\"')
                                    .replace(/\x08/g, "\\b")
                                    .replace(/\t/g, "\\t")
                                    .replace(/\n/g, "\\n")
                                    .replace(/\f/g, "\\f")
                                    .replace(/\r/g, "\\r")
                                    .replace(/[\x00-\x07\x0B\x0E\x0F]/g, function(ch) { return "\\x0" + hex(ch); })
                                    .replace(/[\x10-\x1F\x80-\xFF]/g, function(ch) { return "\\x" + hex(ch); })
                                    .replace(/[\u0180-\u0FFF]/g, function(ch) { return "\\u0" + hex(ch); })
                                    .replace(/[\u1080-\uFFFF]/g, function(ch) { return "\\u" + hex(ch); });
                            }

                            var expectedDescs = new Array(expected.length),
                                expectedDesc,
                                foundDesc,
                                i;

                            for (i = 0; i < expected.length; i++) {
                                expectedDescs[i] = expected[i].description;
                            }

                            expectedDesc = expected.length > 1
                                ? expectedDescs.slice(0, -1).join(", ") + " or " + expectedDescs[expected.length - 1]
                                : expectedDescs[0];

                            foundDesc = found ? "\"" + stringEscape(found) + "\"" : "end of input";

                            return "Expected " + expectedDesc + " but " + foundDesc + " found.";
                        }

                        var posDetails = peg$computePosDetails(pos),
                            found = pos < input.length ? input.charAt(pos) : null;

                        if (expected !== null) {
                            cleanupExpected(expected);
                        }

                        return new SyntaxError(
                            message !== null ? message : buildMessage(expected, found),
                            expected,
                            found,
                            pos,
                            posDetails.line,
                            posDetails.column
                        );
                    }

                    function peg$parsestart() {
                        var s0, s1;

                        s0 = peg$currPos;
                        s1 = peg$parsemessageFormatPattern();
                        if (s1 !== peg$FAILED) {
                            peg$reportedPos = s0;
                            s1 = peg$c0(s1);
                        }
                        s0 = s1;

                        return s0;
                    }

                    function peg$parsemessageFormatPattern() {
                        var s0, s1, s2, s3;

                        s0 = peg$currPos;
                        s1 = peg$parsestring();
                        if (s1 !== peg$FAILED) {
                            s2 = [];
                            s3 = peg$parsemessageFormatPatternRight();
                            while (s3 !== peg$FAILED) {
                                s2.push(s3);
                                s3 = peg$parsemessageFormatPatternRight();
                            }
                            if (s2 !== peg$FAILED) {
                                peg$reportedPos = s0;
                                s1 = peg$c3(s1, s2);
                                s0 = s1;
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }

                        return s0;
                    }

                    function peg$parsemessageFormatPatternRight() {
                        var s0, s1, s2, s3, s4, s5, s6;

                        s0 = peg$currPos;
                        if (input.charCodeAt(peg$currPos) === 123) {
                            s1 = peg$c4;
                            peg$currPos++;
                        } else {
                            s1 = peg$FAILED;
                            if (peg$silentFails === 0) {
                                peg$fail(peg$c5);
                            }
                        }
                        if (s1 !== peg$FAILED) {
                            s2 = peg$parse_();
                            if (s2 !== peg$FAILED) {
                                s3 = peg$parsemessageFormatElement();
                                if (s3 !== peg$FAILED) {
                                    s4 = peg$parse_();
                                    if (s4 !== peg$FAILED) {
                                        if (input.charCodeAt(peg$currPos) === 125) {
                                            s5 = peg$c6;
                                            peg$currPos++;
                                        } else {
                                            s5 = peg$FAILED;
                                            if (peg$silentFails === 0) {
                                                peg$fail(peg$c7);
                                            }
                                        }
                                        if (s5 !== peg$FAILED) {
                                            s6 = peg$parsestring();
                                            if (s6 !== peg$FAILED) {
                                                peg$reportedPos = s0;
                                                s1 = peg$c8(s3, s6);
                                                s0 = s1;
                                            } else {
                                                peg$currPos = s0;
                                                s0 = peg$c1;
                                            }
                                        } else {
                                            peg$currPos = s0;
                                            s0 = peg$c1;
                                        }
                                    } else {
                                        peg$currPos = s0;
                                        s0 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s0;
                                    s0 = peg$c1;
                                }
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }

                        return s0;
                    }

                    function peg$parsemessageFormatElement() {
                        var s0, s1, s2, s3, s4;

                        s0 = peg$currPos;
                        s1 = peg$parseid();
                        if (s1 !== peg$FAILED) {
                            s2 = peg$currPos;
                            if (input.charCodeAt(peg$currPos) === 44) {
                                s3 = peg$c10;
                                peg$currPos++;
                            } else {
                                s3 = peg$FAILED;
                                if (peg$silentFails === 0) {
                                    peg$fail(peg$c11);
                                }
                            }
                            if (s3 !== peg$FAILED) {
                                s4 = peg$parseelementFormat();
                                if (s4 !== peg$FAILED) {
                                    s3 = [s3, s4];
                                    s2 = s3;
                                } else {
                                    peg$currPos = s2;
                                    s2 = peg$c1;
                                }
                            } else {
                                peg$currPos = s2;
                                s2 = peg$c1;
                            }
                            if (s2 === peg$FAILED) {
                                s2 = peg$c9;
                            }
                            if (s2 !== peg$FAILED) {
                                peg$reportedPos = s0;
                                s1 = peg$c12(s1, s2);
                                s0 = s1;
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }

                        return s0;
                    }

                    function peg$parseelementFormat() {
                        var s0, s1, s2, s3, s4, s5, s6, s7;

                        s0 = peg$currPos;
                        s1 = peg$parse_();
                        if (s1 !== peg$FAILED) {
                            if (input.substr(peg$currPos, 6) === peg$c13) {
                                s2 = peg$c13;
                                peg$currPos += 6;
                            } else {
                                s2 = peg$FAILED;
                                if (peg$silentFails === 0) {
                                    peg$fail(peg$c14);
                                }
                            }
                            if (s2 !== peg$FAILED) {
                                s3 = peg$parse_();
                                if (s3 !== peg$FAILED) {
                                    if (input.charCodeAt(peg$currPos) === 44) {
                                        s4 = peg$c10;
                                        peg$currPos++;
                                    } else {
                                        s4 = peg$FAILED;
                                        if (peg$silentFails === 0) {
                                            peg$fail(peg$c11);
                                        }
                                    }
                                    if (s4 !== peg$FAILED) {
                                        s5 = peg$parse_();
                                        if (s5 !== peg$FAILED) {
                                            s6 = peg$parsepluralStyle();
                                            if (s6 !== peg$FAILED) {
                                                s7 = peg$parse_();
                                                if (s7 !== peg$FAILED) {
                                                    peg$reportedPos = s0;
                                                    s1 = peg$c15(s2, s6);
                                                    s0 = s1;
                                                } else {
                                                    peg$currPos = s0;
                                                    s0 = peg$c1;
                                                }
                                            } else {
                                                peg$currPos = s0;
                                                s0 = peg$c1;
                                            }
                                        } else {
                                            peg$currPos = s0;
                                            s0 = peg$c1;
                                        }
                                    } else {
                                        peg$currPos = s0;
                                        s0 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s0;
                                    s0 = peg$c1;
                                }
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }
                        if (s0 === peg$FAILED) {
                            s0 = peg$currPos;
                            s1 = peg$parse_();
                            if (s1 !== peg$FAILED) {
                                if (input.substr(peg$currPos, 13) === peg$c16) {
                                    s2 = peg$c16;
                                    peg$currPos += 13;
                                } else {
                                    s2 = peg$FAILED;
                                    if (peg$silentFails === 0) {
                                        peg$fail(peg$c17);
                                    }
                                }
                                if (s2 !== peg$FAILED) {
                                    s3 = peg$parse_();
                                    if (s3 !== peg$FAILED) {
                                        if (input.charCodeAt(peg$currPos) === 44) {
                                            s4 = peg$c10;
                                            peg$currPos++;
                                        } else {
                                            s4 = peg$FAILED;
                                            if (peg$silentFails === 0) {
                                                peg$fail(peg$c11);
                                            }
                                        }
                                        if (s4 !== peg$FAILED) {
                                            s5 = peg$parse_();
                                            if (s5 !== peg$FAILED) {
                                                s6 = peg$parseselectStyle();
                                                if (s6 !== peg$FAILED) {
                                                    s7 = peg$parse_();
                                                    if (s7 !== peg$FAILED) {
                                                        peg$reportedPos = s0;
                                                        s1 = peg$c15(s2, s6);
                                                        s0 = s1;
                                                    } else {
                                                        peg$currPos = s0;
                                                        s0 = peg$c1;
                                                    }
                                                } else {
                                                    peg$currPos = s0;
                                                    s0 = peg$c1;
                                                }
                                            } else {
                                                peg$currPos = s0;
                                                s0 = peg$c1;
                                            }
                                        } else {
                                            peg$currPos = s0;
                                            s0 = peg$c1;
                                        }
                                    } else {
                                        peg$currPos = s0;
                                        s0 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s0;
                                    s0 = peg$c1;
                                }
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                            if (s0 === peg$FAILED) {
                                s0 = peg$currPos;
                                s1 = peg$parse_();
                                if (s1 !== peg$FAILED) {
                                    if (input.substr(peg$currPos, 6) === peg$c18) {
                                        s2 = peg$c18;
                                        peg$currPos += 6;
                                    } else {
                                        s2 = peg$FAILED;
                                        if (peg$silentFails === 0) {
                                            peg$fail(peg$c19);
                                        }
                                    }
                                    if (s2 !== peg$FAILED) {
                                        s3 = peg$parse_();
                                        if (s3 !== peg$FAILED) {
                                            if (input.charCodeAt(peg$currPos) === 44) {
                                                s4 = peg$c10;
                                                peg$currPos++;
                                            } else {
                                                s4 = peg$FAILED;
                                                if (peg$silentFails === 0) {
                                                    peg$fail(peg$c11);
                                                }
                                            }
                                            if (s4 !== peg$FAILED) {
                                                s5 = peg$parse_();
                                                if (s5 !== peg$FAILED) {
                                                    s6 = peg$parseselectStyle();
                                                    if (s6 !== peg$FAILED) {
                                                        s7 = peg$parse_();
                                                        if (s7 !== peg$FAILED) {
                                                            peg$reportedPos = s0;
                                                            s1 = peg$c15(s2, s6);
                                                            s0 = s1;
                                                        } else {
                                                            peg$currPos = s0;
                                                            s0 = peg$c1;
                                                        }
                                                    } else {
                                                        peg$currPos = s0;
                                                        s0 = peg$c1;
                                                    }
                                                } else {
                                                    peg$currPos = s0;
                                                    s0 = peg$c1;
                                                }
                                            } else {
                                                peg$currPos = s0;
                                                s0 = peg$c1;
                                            }
                                        } else {
                                            peg$currPos = s0;
                                            s0 = peg$c1;
                                        }
                                    } else {
                                        peg$currPos = s0;
                                        s0 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s0;
                                    s0 = peg$c1;
                                }
                                if (s0 === peg$FAILED) {
                                    s0 = peg$currPos;
                                    s1 = peg$parse_();
                                    if (s1 !== peg$FAILED) {
                                        s2 = peg$parseid();
                                        if (s2 !== peg$FAILED) {
                                            s3 = [];
                                            s4 = peg$parseargStylePattern();
                                            while (s4 !== peg$FAILED) {
                                                s3.push(s4);
                                                s4 = peg$parseargStylePattern();
                                            }
                                            if (s3 !== peg$FAILED) {
                                                peg$reportedPos = s0;
                                                s1 = peg$c20(s2, s3);
                                                s0 = s1;
                                            } else {
                                                peg$currPos = s0;
                                                s0 = peg$c1;
                                            }
                                        } else {
                                            peg$currPos = s0;
                                            s0 = peg$c1;
                                        }
                                    } else {
                                        peg$currPos = s0;
                                        s0 = peg$c1;
                                    }
                                }
                            }
                        }

                        return s0;
                    }

                    function peg$parsepluralStyle() {
                        var s0, s1;

                        s0 = peg$currPos;
                        s1 = peg$parsepluralFormatPattern();
                        if (s1 !== peg$FAILED) {
                            peg$reportedPos = s0;
                            s1 = peg$c21(s1);
                        }
                        s0 = s1;

                        return s0;
                    }

                    function peg$parseselectStyle() {
                        var s0, s1;

                        s0 = peg$currPos;
                        s1 = peg$parseselectFormatPattern();
                        if (s1 !== peg$FAILED) {
                            peg$reportedPos = s0;
                            s1 = peg$c22(s1);
                        }
                        s0 = s1;

                        return s0;
                    }

                    function peg$parsepluralFormatPattern() {
                        var s0, s1, s2, s3;

                        s0 = peg$currPos;
                        s1 = peg$parseoffsetPattern();
                        if (s1 === peg$FAILED) {
                            s1 = peg$c9;
                        }
                        if (s1 !== peg$FAILED) {
                            s2 = [];
                            s3 = peg$parsepluralForms();
                            while (s3 !== peg$FAILED) {
                                s2.push(s3);
                                s3 = peg$parsepluralForms();
                            }
                            if (s2 !== peg$FAILED) {
                                peg$reportedPos = s0;
                                s1 = peg$c23(s1, s2);
                                s0 = s1;
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }

                        return s0;
                    }

                    function peg$parseoffsetPattern() {
                        var s0, s1, s2, s3, s4, s5, s6, s7;

                        s0 = peg$currPos;
                        s1 = peg$parse_();
                        if (s1 !== peg$FAILED) {
                            if (input.substr(peg$currPos, 6) === peg$c24) {
                                s2 = peg$c24;
                                peg$currPos += 6;
                            } else {
                                s2 = peg$FAILED;
                                if (peg$silentFails === 0) {
                                    peg$fail(peg$c25);
                                }
                            }
                            if (s2 !== peg$FAILED) {
                                s3 = peg$parse_();
                                if (s3 !== peg$FAILED) {
                                    if (input.charCodeAt(peg$currPos) === 58) {
                                        s4 = peg$c26;
                                        peg$currPos++;
                                    } else {
                                        s4 = peg$FAILED;
                                        if (peg$silentFails === 0) {
                                            peg$fail(peg$c27);
                                        }
                                    }
                                    if (s4 !== peg$FAILED) {
                                        s5 = peg$parse_();
                                        if (s5 !== peg$FAILED) {
                                            s6 = peg$parsedigits();
                                            if (s6 !== peg$FAILED) {
                                                s7 = peg$parse_();
                                                if (s7 !== peg$FAILED) {
                                                    peg$reportedPos = s0;
                                                    s1 = peg$c28(s6);
                                                    s0 = s1;
                                                } else {
                                                    peg$currPos = s0;
                                                    s0 = peg$c1;
                                                }
                                            } else {
                                                peg$currPos = s0;
                                                s0 = peg$c1;
                                            }
                                        } else {
                                            peg$currPos = s0;
                                            s0 = peg$c1;
                                        }
                                    } else {
                                        peg$currPos = s0;
                                        s0 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s0;
                                    s0 = peg$c1;
                                }
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }

                        return s0;
                    }

                    function peg$parseselectFormatPattern() {
                        var s0, s1, s2;

                        s0 = peg$currPos;
                        s1 = [];
                        s2 = peg$parsepluralForms();
                        while (s2 !== peg$FAILED) {
                            s1.push(s2);
                            s2 = peg$parsepluralForms();
                        }
                        if (s1 !== peg$FAILED) {
                            peg$reportedPos = s0;
                            s1 = peg$c29(s1);
                        }
                        s0 = s1;

                        return s0;
                    }

                    function peg$parsepluralForms() {
                        var s0, s1, s2, s3, s4, s5, s6, s7, s8;

                        s0 = peg$currPos;
                        s1 = peg$parse_();
                        if (s1 !== peg$FAILED) {
                            s2 = peg$parsestringKey();
                            if (s2 !== peg$FAILED) {
                                s3 = peg$parse_();
                                if (s3 !== peg$FAILED) {
                                    if (input.charCodeAt(peg$currPos) === 123) {
                                        s4 = peg$c4;
                                        peg$currPos++;
                                    } else {
                                        s4 = peg$FAILED;
                                        if (peg$silentFails === 0) {
                                            peg$fail(peg$c5);
                                        }
                                    }
                                    if (s4 !== peg$FAILED) {
                                        s5 = peg$parse_();
                                        if (s5 !== peg$FAILED) {
                                            s6 = peg$parsemessageFormatPattern();
                                            if (s6 !== peg$FAILED) {
                                                s7 = peg$parse_();
                                                if (s7 !== peg$FAILED) {
                                                    if (input.charCodeAt(peg$currPos) === 125) {
                                                        s8 = peg$c6;
                                                        peg$currPos++;
                                                    } else {
                                                        s8 = peg$FAILED;
                                                        if (peg$silentFails === 0) {
                                                            peg$fail(peg$c7);
                                                        }
                                                    }
                                                    if (s8 !== peg$FAILED) {
                                                        peg$reportedPos = s0;
                                                        s1 = peg$c30(s2, s6);
                                                        s0 = s1;
                                                    } else {
                                                        peg$currPos = s0;
                                                        s0 = peg$c1;
                                                    }
                                                } else {
                                                    peg$currPos = s0;
                                                    s0 = peg$c1;
                                                }
                                            } else {
                                                peg$currPos = s0;
                                                s0 = peg$c1;
                                            }
                                        } else {
                                            peg$currPos = s0;
                                            s0 = peg$c1;
                                        }
                                    } else {
                                        peg$currPos = s0;
                                        s0 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s0;
                                    s0 = peg$c1;
                                }
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }

                        return s0;
                    }

                    function peg$parsestringKey() {
                        var s0, s1, s2;

                        s0 = peg$currPos;
                        s1 = peg$parseid();
                        if (s1 !== peg$FAILED) {
                            peg$reportedPos = s0;
                            s1 = peg$c31(s1);
                        }
                        s0 = s1;
                        if (s0 === peg$FAILED) {
                            s0 = peg$currPos;
                            if (input.charCodeAt(peg$currPos) === 61) {
                                s1 = peg$c32;
                                peg$currPos++;
                            } else {
                                s1 = peg$FAILED;
                                if (peg$silentFails === 0) {
                                    peg$fail(peg$c33);
                                }
                            }
                            if (s1 !== peg$FAILED) {
                                s2 = peg$parsedigits();
                                if (s2 !== peg$FAILED) {
                                    peg$reportedPos = s0;
                                    s1 = peg$c28(s2);
                                    s0 = s1;
                                } else {
                                    peg$currPos = s0;
                                    s0 = peg$c1;
                                }
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        }

                        return s0;
                    }

                    function peg$parseargStylePattern() {
                        var s0, s1, s2, s3, s4, s5;

                        s0 = peg$currPos;
                        s1 = peg$parse_();
                        if (s1 !== peg$FAILED) {
                            if (input.charCodeAt(peg$currPos) === 44) {
                                s2 = peg$c10;
                                peg$currPos++;
                            } else {
                                s2 = peg$FAILED;
                                if (peg$silentFails === 0) {
                                    peg$fail(peg$c11);
                                }
                            }
                            if (s2 !== peg$FAILED) {
                                s3 = peg$parse_();
                                if (s3 !== peg$FAILED) {
                                    s4 = peg$parseid();
                                    if (s4 !== peg$FAILED) {
                                        s5 = peg$parse_();
                                        if (s5 !== peg$FAILED) {
                                            peg$reportedPos = s0;
                                            s1 = peg$c34(s4);
                                            s0 = s1;
                                        } else {
                                            peg$currPos = s0;
                                            s0 = peg$c1;
                                        }
                                    } else {
                                        peg$currPos = s0;
                                        s0 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s0;
                                    s0 = peg$c1;
                                }
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }

                        return s0;
                    }

                    function peg$parsestring() {
                        var s0, s1, s2, s3, s4, s5, s6;

                        s0 = peg$currPos;
                        s1 = peg$parse_();
                        if (s1 !== peg$FAILED) {
                            s2 = [];
                            s3 = peg$currPos;
                            s4 = peg$parse_();
                            if (s4 !== peg$FAILED) {
                                s5 = peg$parsechars();
                                if (s5 !== peg$FAILED) {
                                    s6 = peg$parse_();
                                    if (s6 !== peg$FAILED) {
                                        s4 = [s4, s5, s6];
                                        s3 = s4;
                                    } else {
                                        peg$currPos = s3;
                                        s3 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s3;
                                    s3 = peg$c1;
                                }
                            } else {
                                peg$currPos = s3;
                                s3 = peg$c1;
                            }
                            while (s3 !== peg$FAILED) {
                                s2.push(s3);
                                s3 = peg$currPos;
                                s4 = peg$parse_();
                                if (s4 !== peg$FAILED) {
                                    s5 = peg$parsechars();
                                    if (s5 !== peg$FAILED) {
                                        s6 = peg$parse_();
                                        if (s6 !== peg$FAILED) {
                                            s4 = [s4, s5, s6];
                                            s3 = s4;
                                        } else {
                                            peg$currPos = s3;
                                            s3 = peg$c1;
                                        }
                                    } else {
                                        peg$currPos = s3;
                                        s3 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s3;
                                    s3 = peg$c1;
                                }
                            }
                            if (s2 !== peg$FAILED) {
                                peg$reportedPos = s0;
                                s1 = peg$c35(s1, s2);
                                s0 = s1;
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }

                        return s0;
                    }

                    function peg$parseid() {
                        var s0, s1, s2, s3, s4;

                        s0 = peg$currPos;
                        s1 = peg$parse_();
                        if (s1 !== peg$FAILED) {
                            if (peg$c36.test(input.charAt(peg$currPos))) {
                                s2 = input.charAt(peg$currPos);
                                peg$currPos++;
                            } else {
                                s2 = peg$FAILED;
                                if (peg$silentFails === 0) {
                                    peg$fail(peg$c37);
                                }
                            }
                            if (s2 !== peg$FAILED) {
                                s3 = [];
                                if (peg$c38.test(input.charAt(peg$currPos))) {
                                    s4 = input.charAt(peg$currPos);
                                    peg$currPos++;
                                } else {
                                    s4 = peg$FAILED;
                                    if (peg$silentFails === 0) {
                                        peg$fail(peg$c39);
                                    }
                                }
                                while (s4 !== peg$FAILED) {
                                    s3.push(s4);
                                    if (peg$c38.test(input.charAt(peg$currPos))) {
                                        s4 = input.charAt(peg$currPos);
                                        peg$currPos++;
                                    } else {
                                        s4 = peg$FAILED;
                                        if (peg$silentFails === 0) {
                                            peg$fail(peg$c39);
                                        }
                                    }
                                }
                                if (s3 !== peg$FAILED) {
                                    s4 = peg$parse_();
                                    if (s4 !== peg$FAILED) {
                                        peg$reportedPos = s0;
                                        s1 = peg$c40(s2, s3);
                                        s0 = s1;
                                    } else {
                                        peg$currPos = s0;
                                        s0 = peg$c1;
                                    }
                                } else {
                                    peg$currPos = s0;
                                    s0 = peg$c1;
                                }
                            } else {
                                peg$currPos = s0;
                                s0 = peg$c1;
                            }
                        } else {
                            peg$currPos = s0;
                            s0 = peg$c1;
                        }

                        return s0;
                    }

                    function peg$parsechars() {
                        var s0, s1, s2;

                        s0 = peg$currPos;
                        s1 = [];
                        s2 = peg$parsechar();
                        if (s2 !== peg$FAILED) {
                            while (s2 !== peg$FAILED) {
                                s1.push(s2);
                                s2 = peg$parsechar();
                            }
                        } else {
                            s1 = peg$c1;
                        }
                        if (s1 !== peg$FAILED) {
                            peg$reportedPos = s0;
                            s1 = peg$c41(s1);
                        }
                        s0 = s1;

                        return s0;
                    }

                    function peg$parsechar() {
                        var s0, s1, s2, s3, s4, s5;

                        s0 = peg$currPos;
                        if (peg$c42.test(input.charAt(peg$currPos))) {
                            s1 = input.charAt(peg$currPos);
                            peg$currPos++;
                        } else {
                            s1 = peg$FAILED;
                            if (peg$silentFails === 0) {
                                peg$fail(peg$c43);
                            }
                        }
                        if (s1 !== peg$FAILED) {
                            peg$reportedPos = s0;
                            s1 = peg$c44(s1);
                        }
                        s0 = s1;
                        if (s0 === peg$FAILED) {
                            s0 = peg$currPos;
                            if (input.substr(peg$currPos, 2) === peg$c45) {
                                s1 = peg$c45;
                                peg$currPos += 2;
                            } else {
                                s1 = peg$FAILED;
                                if (peg$silentFails === 0) {
                                    peg$fail(peg$c46);
                                }
                            }
                            if (s1 !== peg$FAILED) {
                                peg$reportedPos = s0;
                                s1 = peg$c47();
                            }
                            s0 = s1;
                            if (s0 === peg$FAILED) {
                                s0 = peg$currPos;
                                if (input.substr(peg$currPos, 2) === peg$c48) {
                                    s1 = peg$c48;
                                    peg$currPos += 2;
                                } else {
                                    s1 = peg$FAILED;
                                    if (peg$silentFails === 0) {
                                        peg$fail(peg$c49);
                                    }
                                }
                                if (s1 !== peg$FAILED) {
                                    peg$reportedPos = s0;
                                    s1 = peg$c50();
                                }
                                s0 = s1;
                                if (s0 === peg$FAILED) {
                                    s0 = peg$currPos;
                                    if (input.substr(peg$currPos, 2) === peg$c51) {
                                        s1 = peg$c51;
                                        peg$currPos += 2;
                                    } else {
                                        s1 = peg$FAILED;
                                        if (peg$silentFails === 0) {
                                            peg$fail(peg$c52);
                                        }
                                    }
                                    if (s1 !== peg$FAILED) {
                                        peg$reportedPos = s0;
                                        s1 = peg$c53();
                                    }
                                    s0 = s1;
                                    if (s0 === peg$FAILED) {
                                        s0 = peg$currPos;
                                        if (input.substr(peg$currPos, 2) === peg$c54) {
                                            s1 = peg$c54;
                                            peg$currPos += 2;
                                        } else {
                                            s1 = peg$FAILED;
                                            if (peg$silentFails === 0) {
                                                peg$fail(peg$c55);
                                            }
                                        }
                                        if (s1 !== peg$FAILED) {
                                            s2 = peg$parsehexDigit();
                                            if (s2 !== peg$FAILED) {
                                                s3 = peg$parsehexDigit();
                                                if (s3 !== peg$FAILED) {
                                                    s4 = peg$parsehexDigit();
                                                    if (s4 !== peg$FAILED) {
                                                        s5 = peg$parsehexDigit();
                                                        if (s5 !== peg$FAILED) {
                                                            peg$reportedPos = s0;
                                                            s1 = peg$c56(s2, s3, s4, s5);
                                                            s0 = s1;
                                                        } else {
                                                            peg$currPos = s0;
                                                            s0 = peg$c1;
                                                        }
                                                    } else {
                                                        peg$currPos = s0;
                                                        s0 = peg$c1;
                                                    }
                                                } else {
                                                    peg$currPos = s0;
                                                    s0 = peg$c1;
                                                }
                                            } else {
                                                peg$currPos = s0;
                                                s0 = peg$c1;
                                            }
                                        } else {
                                            peg$currPos = s0;
                                            s0 = peg$c1;
                                        }
                                    }
                                }
                            }
                        }

                        return s0;
                    }

                    function peg$parsedigits() {
                        var s0, s1, s2;

                        s0 = peg$currPos;
                        s1 = [];
                        if (peg$c57.test(input.charAt(peg$currPos))) {
                            s2 = input.charAt(peg$currPos);
                            peg$currPos++;
                        } else {
                            s2 = peg$FAILED;
                            if (peg$silentFails === 0) {
                                peg$fail(peg$c58);
                            }
                        }
                        if (s2 !== peg$FAILED) {
                            while (s2 !== peg$FAILED) {
                                s1.push(s2);
                                if (peg$c57.test(input.charAt(peg$currPos))) {
                                    s2 = input.charAt(peg$currPos);
                                    peg$currPos++;
                                } else {
                                    s2 = peg$FAILED;
                                    if (peg$silentFails === 0) {
                                        peg$fail(peg$c58);
                                    }
                                }
                            }
                        } else {
                            s1 = peg$c1;
                        }
                        if (s1 !== peg$FAILED) {
                            peg$reportedPos = s0;
                            s1 = peg$c59(s1);
                        }
                        s0 = s1;

                        return s0;
                    }

                    function peg$parsehexDigit() {
                        var s0;

                        if (peg$c60.test(input.charAt(peg$currPos))) {
                            s0 = input.charAt(peg$currPos);
                            peg$currPos++;
                        } else {
                            s0 = peg$FAILED;
                            if (peg$silentFails === 0) {
                                peg$fail(peg$c61);
                            }
                        }

                        return s0;
                    }

                    function peg$parse_() {
                        var s0, s1, s2;

                        peg$silentFails++;
                        s0 = peg$currPos;
                        s1 = [];
                        s2 = peg$parsewhitespace();
                        while (s2 !== peg$FAILED) {
                            s1.push(s2);
                            s2 = peg$parsewhitespace();
                        }
                        if (s1 !== peg$FAILED) {
                            peg$reportedPos = s0;
                            s1 = peg$c63(s1);
                        }
                        s0 = s1;
                        peg$silentFails--;
                        if (s0 === peg$FAILED) {
                            s1 = peg$FAILED;
                            if (peg$silentFails === 0) {
                                peg$fail(peg$c62);
                            }
                        }

                        return s0;
                    }

                    function peg$parsewhitespace() {
                        var s0;

                        if (peg$c64.test(input.charAt(peg$currPos))) {
                            s0 = input.charAt(peg$currPos);
                            peg$currPos++;
                        } else {
                            s0 = peg$FAILED;
                            if (peg$silentFails === 0) {
                                peg$fail(peg$c65);
                            }
                        }

                        return s0;
                    }

                    peg$result = peg$startRuleFunction();

                    if (peg$result !== peg$FAILED && peg$currPos === input.length) {
                        return peg$result;
                    } else {
                        if (peg$result !== peg$FAILED && peg$currPos < input.length) {
                            peg$fail({ type: "end", description: "end of input" });
                        }

                        throw peg$buildException(null, peg$maxFailExpected, peg$maxFailPos);
                    }
                }

                return {
                    SyntaxError: SyntaxError,
                    parse: parse
                };
            })();

            MessageFormat._parse = function() {
                // Bind to itself so error handling works
                return mparser.parse.apply(mparser, arguments);
            };

            var propname = function(s) {
                return /^[A-Z_$][0-9A-Z_$]*$/i.test(s) ? s : JSON.stringify(s);
            };

            MessageFormat.prototype._precompile = function(ast, data) {
                data = data || { keys: {}, offset: {} };
                var r = [], i, tmp, args = [];

                switch (ast.type) {
                case "messageFormatPattern":
                    for (i = 0; i < ast.statements.length; ++i) {
                        r.push(this._precompile(ast.statements[i], data));
                    }
                    tmp = r.join("+") || '""';
                    return data.pf_count ? tmp : "function(d){return " + tmp + "}";

                case "messageFormatPatternRight":
                    for (i = 0; i < ast.statements.length; ++i) {
                        r.push(this._precompile(ast.statements[i], data));
                    }
                    return r.join("+");

                case "messageFormatElement":
                    data.pf_count = data.pf_count || 0;
                    if (ast.output) {
                        return "d[" + JSON.stringify(ast.argumentIndex) + "]";
                    } else {
                        data.keys[data.pf_count] = JSON.stringify(ast.argumentIndex);
                        return this._precompile(ast.elementFormat, data);
                    }
                    return "";

                case "elementFormat":
                    var args = ["d[" + data.keys[data.pf_count] + "]"];
                    switch (ast.key) {
                    case "select":
                        args.push(this._precompile(ast.val, data));
                        return "_s(" + args.join(",") + ")";
                    case "selectordinal":
                        args = args.concat([
                            0, "pf[" + JSON.stringify(this.lc[0]) + "]", this._precompile(ast.val, data), 1
                        ]);
                        return "_p(" + args.join(",") + ")";
                    case "plural":
                        data.offset[data.pf_count || 0] = ast.val.offset || 0;
                        args = args.concat([
                            data.offset[data.pf_count] || 0, "pf[" + JSON.stringify(this.lc[0]) + "]",
                            this._precompile(ast.val, data)
                        ]);
                        return "_p(" + args.join(",") + ")";
                    default:
                        if (this.withIntlSupport &&
                            !(ast.key in this.runtime.fmt) &&
                            (ast.key in MessageFormat.formatters)) {
                            tmp = MessageFormat.formatters[ast.key];
                            this.runtime.fmt[ast.key] = (typeof tmp(this) == "function") ? tmp(this) : tmp;
                        }
                        args.push(JSON.stringify(this.lc));
                        if (ast.val && ast.val.length)
                            args.push(JSON.stringify(ast.val.length == 1 ? ast.val[0] : ast.val));
                        return "fmt." + ast.key + "(" + args.join(",") + ")";
                    }

                case "pluralFormatPattern":
                case "selectFormatPattern":
                    data.pf_count = data.pf_count || 0;
                    if (ast.type == "selectFormatPattern") data.offset[data.pf_count] = 0;
                    var needOther = true;
                    for (i = 0; i < ast.pluralForms.length; ++i) {
                        var key = ast.pluralForms[i].key;
                        if (key === "other") {
                            needOther = false;
                        }
                        var data_copy = JSON.parse(JSON.stringify(data));
                        data_copy.pf_count++;
                        r.push(propname(key) + ":" + this._precompile(ast.pluralForms[i].val, data_copy));
                    }
                    if (needOther) {
                        throw new Error("No 'other' form found in " + ast.type + " " + data.pf_count);
                    }
                    return "{" + r.join(",") + "}";

                case "string":
                    tmp = '"' + (ast.val || "").replace(/\n/g, "\\n").replace(/"/g, '\\"') + '"';
                    if (data.pf_count) {
                        args = ["d[" + data.keys[data.pf_count - 1] + "]"];
                        if (data.offset[data.pf_count - 1]) args.push(data.offset[data.pf_count - 1]);
                        tmp = tmp.replace(/(^|[^\\])#/g, '$1"+' + "_n(" + args.join(",") + ')+"');
                        tmp = tmp.replace(/^""\+/, "").replace(/\+""$/, "");
                    }
                    return tmp;

                default:
                    throw new Error("Bad AST type: " + ast.type);
                }
            };

            MessageFormat.prototype.compile = function(messages, opt) {
                var r = {},
                    lc0 = this.lc,
                    compileMsg = function(self, msg) {
                        try {
                            var ast = MessageFormat._parse(msg).program;
                            return self._precompile(ast);
                        } catch (e) {
                            throw new Error((ast ? "Precompiler" : "Parser") + " error: " + e.toString());
                        }
                    },
                    stringify = function(r) {
                        if (typeof r != "object") return r;
                        var o = [];
                        for (var k in r) o.push(propname(k) + ":" + stringify(r[k]));
                        return "{\n" + o.join(",\n") + "}";
                    };

                if (typeof messages == "string") {
                    var f = new Function("_n,_p,_s,pf,fmt", "return " + compileMsg(this, messages));
                    return f(this.runtime._n, this.runtime._p, this.runtime._s, this.runtime.pf, this.runtime.fmt);
                }

                opt = opt || {};

                for (var ns in messages) {
                    if (opt.locale) this.lc = opt.locale[ns] && [].concat(opt.locale[ns]) || lc0;
                    if (typeof messages[ns] == "string") {
                        try {
                            r[ns] = compileMsg(this, messages[ns]);
                        } catch (e) {
                            e.message = e.message.replace(":", " with `" + ns + "`:");
                            throw e;
                        }
                    } else {
                        r[ns] = {};
                        for (var key in messages[ns]) {
                            try {
                                r[ns][key] = compileMsg(this, messages[ns][key]);
                            } catch (e) {
                                e.message = e.message.replace(":", " with `" + key + "` in `" + ns + "`:");
                                throw e;
                            }
                        }
                    }
                }

                this.lc = lc0;
                var s = "var\n" + this.runtime.toString() + ";\n\n";
                switch (opt.global || "") {
                case "exports":
                    var o = [];
                    for (var k in r) o.push("exports[" + JSON.stringify(k) + "] = " + stringify(r[k]));
                    return new Function(s + o.join(";\n"));
                case "module.exports":
                    return new Function(s + "module.exports = " + stringify(r));
                case "":
                    return new Function(s + "return " + stringify(r));
                default:
                    return new Function("G", s + "G[" + JSON.stringify(opt.global) + "] = " + stringify(r));
                }
            };


            return MessageFormat;
        }());
/* jshint ignore:end */


        var validateMessageBundle = function(cldr) {
            validate(
                "E_MISSING_MESSAGE_BUNDLE",
                "Missing message bundle for locale `{locale}`.",
                cldr.attributes.bundle && cldr.get("globalize-messages/{bundle}") !== undefined,
                {
                    locale: cldr.locale
                }
            );
        };


        var validateMessagePresence = function(path, value) {
            path = path.join("/");
            validate("E_MISSING_MESSAGE",
                "Missing required message content `{path}`.",
                value !== undefined,
                { path: path });
        };


        var validateMessageType = function(path, value) {
            path = path.join("/");
            validate(
                "E_INVALID_MESSAGE",
                "Invalid message content `{path}`. {expected} expected.",
                typeof value === "string",
                {
                    expected: "a string",
                    path: path
                }
            );
        };


        var validateParameterTypeMessageVariables = function(value, name) {
            validateParameterType(
                value,
                name,
                value === undefined || isPlainObject(value) || Array.isArray(value),
                "Array or Plain Object"
            );
        };


        var validatePluralModulePresence = function() {
            validate("E_MISSING_PLURAL_MODULE",
                "Plural module not loaded.",
                Globalize.plural !== undefined,
                {});
        };


        var slice = [].slice;

        function MessageFormatInit(globalize, cldr) {
            var plural;
            return new MessageFormat(cldr.locale,
                function(value) {
                    if (!plural) {
                        validatePluralModulePresence();
                        plural = globalize.pluralGenerator();
                    }
                    return plural(value);
                });
        }

/**
 * .loadMessages( json )
 *
 * @json [JSON]
 *
 * Load translation data.
 */
        Globalize.loadMessages = function(json) {
            var locale,
                customData = {
                    "globalize-messages": json,
                    "main": {}
                };

            validateParameterPresence(json, "json");
            validateParameterTypePlainObject(json, "json");

            // Set available bundles by populating customData main dataset.
            for (locale in json) {
                if (json.hasOwnProperty(locale)) {
                    customData.main[locale] = {};
                }
            }

            Cldr.load(customData);
        };

/**
 * .messageFormatter( path )
 *
 * @path [String or Array]
 *
 * Format a message given its path.
 */
        Globalize.messageFormatter =
            Globalize.prototype.messageFormatter = function(path) {
                var cldr, formatter, message;

                validateParameterPresence(path, "path");
                validateParameterType(path,
                    "path",
                    typeof path === "string" || Array.isArray(path),
                    "a String nor an Array");

                path = alwaysArray(path);
                cldr = this.cldr;

                validateDefaultLocale(cldr);
                validateMessageBundle(cldr);

                message = cldr.get(["globalize-messages/{bundle}"].concat(path));
                validateMessagePresence(path, message);

                // If message is an Array, concatenate it.
                if (Array.isArray(message)) {
                    message = message.join(" ");
                }
                validateMessageType(path, message);

                formatter = MessageFormatInit(this, cldr).compile(message);

                return function(variables) {
                    if (typeof variables === "number" || typeof variables === "string") {
                        variables = slice.call(arguments, 0);
                    }
                    validateParameterTypeMessageVariables(variables, "variables");
                    return formatter(variables);
                };
            };

/**
 * .formatMessage( path [, variables] )
 *
 * @path [String or Array]
 *
 * @variables [Number, String, Array or Object]
 *
 * Format a message given its path.
 */
        Globalize.formatMessage =
            Globalize.prototype.formatMessage = function(path /* , variables */) {
                return this.messageFormatter(path).apply({}, slice.call(arguments, 1));
            };

        return Globalize;


    }));