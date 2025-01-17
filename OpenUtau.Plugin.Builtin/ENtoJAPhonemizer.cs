﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using OpenUtau.Api;
using WanaKanaNet;

namespace OpenUtau.Plugin.Builtin {
    [Phonemizer("English to Japanese Phonemizer", "EN to JA", "TUBS")]
    public class ENtoJAPhonemizer : SyllableBasedPhonemizer {
        protected override string[] GetVowels() => "a i u e o ay ey oy ow aw".Split();

        protected override string[] GetConsonants() =>
            "b by ch d dh f g gy h hy j k ky l ly m my n ny ng p py r ry s sh t ts th v w y z zh".Split();
        protected override string GetDictionaryName() => "cmudict-0_7b.txt";
        protected override Dictionary<string, string> GetDictionaryPhonemesReplacement() => new Dictionary<string, string> {
            { "AA", "a" },
            { "AA0", "a" },
            { "AA1", "a" },
            { "AA2", "a" },
            { "AE", "e" },
            { "AE0", "e" },
            { "AE1", "e" },
            { "AE2", "e" },
            { "AH", "a" },
            { "AH0", "a" },
            { "AH1", "a" },
            { "AH2", "a" },
            { "AO", "o" },
            { "AO0", "o" },
            { "AO1", "o" },
            { "AO2", "o" },
            { "AW", "aw" },
            { "AW0", "aw" },
            { "AW1", "aw" },
            { "AW2", "aw" },
            { "AY", "ay" },
            { "AY0", "ay" },
            { "AY1", "ay" },
            { "AY2", "ay" },
            { "B", "b" },
            { "CH", "ch" },
            { "D", "d" },
            { "DH", "dh" },
            { "EH", "e" },
            { "EH0", "e" },
            { "EH1", "e" },
            { "EH2", "e" },
            { "ER", "o" },
            { "ER0", "o" },
            { "ER1", "o" },
            { "ER2", "o" },
            { "EY", "ey" },
            { "EY0", "ey" },
            { "EY1", "ey" },
            { "EY2", "ey" },
            { "F", "f" },
            { "G", "g" },
            { "HH", "h" },
            { "IH", "e" },
            { "IH0", "e" },
            { "IH1", "e" },
            { "IH2", "e" },
            { "IY", "i" },
            { "IY0", "i" },
            { "IY1", "i" },
            { "IY2", "i" },
            { "JH", "j" },
            { "K", "k" },
            { "L", "l" },
            { "M", "m" },
            { "N", "n" },
            { "NG", "ng" },
            { "OW", "ow" },
            { "OW0", "ow" },
            { "OW1", "ow" },
            { "OW2", "ow" },
            { "OY", "oy" },
            { "OY0", "oy" },
            { "OY1", "oy" },
            { "OY2", "oy" },
            { "P", "p" },
            { "R", "r" },
            { "S", "s" },
            { "SH", "sh" },
            { "T", "t" },
            { "TH", "th" },
            { "UH", "o" },
            { "UH0", "o" },
            { "UH1", "o" },
            { "UH2", "o" },
            { "UW", "u" },
            { "UW0", "u" },
            { "UW1", "u" },
            { "UW2", "u" },
            { "V", "v" },
            { "W", "w" },
            { "Y", "y" },
            { "Z", "z" },
            { "ZH", "zh" },
        };

        protected override string ReadDictionary(string filename) {
            return Core.Api.Resources.cmudict_0_7b;
        }

        private Dictionary<string, string> StartingConsonant => new Dictionary<string, string> {
            { "", "" },
            { "b", "b" },
            { "by", "by" },
            { "ch", "ch" },
            { "d", "d" },
            { "dh", "d" },
            { "f", "f" },
            { "g", "g" },
            { "gy", "gy" },
            { "h", "h" },
            { "hy", "hy" },
            { "j", "j" },
            { "k", "k" },
            { "ky", "ky" },
            { "l", "r" },
            { "ly", "ry" },
            { "m", "m" },
            { "my", "my" },
            { "n", "n" },
            { "ny", "ny" },
            { "ng", "n" },
            { "p", "p" },
            { "py", "py" },
            { "r", "rr" },
            { "ry", "ry" },
            { "s", "s" },
            { "sh", "sh" },
            { "t", "t" },
            { "ts", "ts" },
            { "th", "s" },
            { "v", "v" },
            { "w", "w" },
            { "y", "y" },
            { "z", "z" },
            { "zh", "sh" },
        };

        private Dictionary<string, string> SoloConsonant => new Dictionary<string, string> {
            { "b", "ぶ" },
            { "by", "び" },
            { "ch", "ちゅ" },
            { "d", "ど" },
            { "dh", "ず" },
            { "f", "ふ" },
            { "g", "ぐ" },
            { "gy", "ぎ" },
            { "h", "ほ" },
            { "hy", "ひ" },
            { "j", "じゅ" },
            { "k", "く" },
            { "ky", "き" },
            { "l", "う" },
            { "ly", "り" },
            { "m", "む" },
            { "my", "み" },
            { "n", "ん" },
            { "ny", "に" },
            { "ng", "ん" },
            { "p", "ぷ" },
            { "py", "ぴ" },
            { "r", "う" },
            { "ry", "り" },
            { "s", "す" },
            { "sh", "しゅ" },
            { "t", "と" },
            { "ts", "つ" },
            { "th", "す" },
            { "v", "ヴ" },
            { "w", "う" },
            { "y", "い" },
            { "z", "ず" },
            { "zh", "しゅ" },
        };

        private string[] SpecialClusters = "ky gy ts ny hy by py my ry ly".Split();

        private Dictionary<string, string> AltCv => new Dictionary<string, string> {
            {"si", "suli" },
            {"zi", "zuli" },
            {"ti", "teli" },
            {"tu", "tolu" },
            {"di", "deli" },
            {"du", "dolu" },
            {"hu", "holu" },
            {"yi", "i" },
            {"wu", "u" },
            {"wo", "ulo" },
            {"rra", "wa" },
            {"rri", "wi" },
            {"rru", "ru" },
            {"rre", "we" },
            {"rro", "ulo" },
        };

        private Dictionary<string, string> ConditionalAlt => new Dictionary<string, string> {
            {"ulo", "wo"},
            {"va", "fa"},
            {"vi", "fi"},
            {"vu", "fu"},
            {"ヴ", "ふ"},
            {"ve", "fe"},
            {"vo", "fo"},
        };

        private Dictionary<string, string[]> ExtraCv => new Dictionary<string, string[]> {
            {"kye", new [] { "ki", "e" } },
            {"gye", new [] { "gi", "e" } },
            {"suli", new [] { "se", "i" } },
            {"she", new [] { "si", "e" } },
            {"zuli", new [] { "ze", "i" } },
            {"je", new [] { "ji", "e" } },
            {"teli", new [] { "te", "i" } },
            {"tolu", new [] { "to", "u" } },
            {"che", new [] { "chi", "e" } },
            {"tsa", new [] { "tsu", "a" } },
            {"tsi", new [] { "tsu", "i" } },
            {"tse", new [] { "tsu", "e" } },
            {"tso", new [] { "tsu", "o" } },
            {"deli", new [] { "de", "i" } },
            {"dolu", new [] { "do", "u" } },
            {"nye", new [] { "ni", "e" } },
            {"hye", new [] { "hi", "e" } },
            {"holu", new [] { "ho", "u" } },
            {"fa", new [] { "fu", "a" } },
            {"fi", new [] { "fu", "i" } },
            {"fe", new [] { "fu", "e" } },
            {"fo", new [] { "fu", "o" } },
            {"bye", new [] { "bi", "e" } },
            {"pye", new [] { "pi", "e" } },
            {"mye", new [] { "mi", "e" } },
            {"ye", new [] { "i", "e" } },
            {"rye", new [] { "ri", "e" } },
            {"wi", new [] { "u", "i" } },
            {"we", new [] { "u", "e" } },
            {"ulo", new [] { "u", "o" } },
        };

        private string [] affricates = "ts ch j".Split();

        protected override string[] GetSymbols(Note note) {
            string[] original = base.GetSymbols(note);
            if (original == null) {
                return null;
            }
            List<string> modified = new List<string>();
            string[] diphthongs = new[] { "ay", "ey", "oy", "ow", "aw" };
            foreach (string s in original) {
                if (diphthongs.Contains(s)) {
                    modified.AddRange(new string[] { s[0].ToString(), s[1].ToString()});
                } else {        
                    modified.Add(s);
                }
            }               
            return modified.ToArray();
        }

        protected override List<string> ProcessSyllable(Syllable syllable) {
            // Skip processing if this note extends the prevous syllable
            if (CanMakeAliasExtension(syllable)) {
                return new List<string> { null };
            }

            var prevV = syllable.prevV;
            var cc = syllable.cc;
            var v = syllable.v;
            var phonemes = new List<string>();
            var usingVC = false;

            if (prevV.Length == 0) {
                prevV = "-";
            }

            // Check CCs for special clusters
            var adjustedCC = new List<string>();
            for (var i = 0; i < cc.Length; i++) {
                if (i == cc.Length - 1) {
                    adjustedCC.Add(cc[i]);
                } else {
                    if (cc[i] == cc[i+1]) {
                        adjustedCC.Add(cc[i]);
                        i++;
                        continue;
                    }
                    var diphone = $"{cc[i]}{cc[i + 1]}";
                    if (SpecialClusters.Contains(diphone)) {
                        adjustedCC.Add(diphone);
                        i++;
                    } else {
                        adjustedCC.Add(cc[i]);
                    }
                }
            }
            cc = adjustedCC.ToArray();

            // Separate CCs and main CV
            var finalCons = "";
            if (cc.Length > 0) {
                finalCons = cc[cc.Length - 1];

                var start = 0;
                (var hasVc, var vcPhonemes) = HasVc(prevV, cc[0], syllable.tone, cc.Length);
                usingVC = hasVc;
                phonemes.AddRange(vcPhonemes);

                if (usingVC) {
                    start = 1;
                }

                for (var i = start;  i < cc.Length - 1; i++) {
                    var cons = SoloConsonant[cc[i]];
                    if (!usingVC) {
                        cons = TryVcv(prevV, cons, syllable.tone);
                    } else {
                        usingVC = false;
                    }
                    if (HasOto(cons, syllable.tone)) {
                        phonemes.Add(cons);
                    } else if (ConditionalAlt.ContainsKey(cons)) {
                        cons = ConditionalAlt[cons];
                        phonemes.Add(TryVcv(prevV, cons, syllable.tone));
                    }
                    prevV = WanaKana.ToRomaji(cons).Last<char>().ToString();
                }
            }

            // Convert to hiragana
            var cv = $"{StartingConsonant[finalCons]}{v}";
            cv = AltCv.ContainsKey(cv) ? AltCv[cv] : cv;
            var hiragana = ToHiragana(cv);
            if (!usingVC) {
                hiragana = TryVcv(prevV, hiragana, syllable.vowelTone);
            } else {
                hiragana = FixCv(hiragana, syllable.vowelTone);
            }

            // Check for nonstandard CV
            var split = false;
            if (HasOto(hiragana, syllable.vowelTone)) {
                phonemes.Add(hiragana);
            } else if (ConditionalAlt.ContainsKey(cv)) {
                cv = ConditionalAlt[cv];
                hiragana = TryVcv(prevV, ToHiragana(cv), syllable.vowelTone);
                if (HasOto(hiragana, syllable.vowelTone)) {
                    phonemes.Add(hiragana);
                } else {
                    split = true;
                }
            } else {
                split = true;
            }

            // Handle nonstandard CV
            if (split && ExtraCv.ContainsKey(cv)) {
                var splitCv = ExtraCv[cv];
                for (var i = 0; i < splitCv.Length; i++) {
                    if (splitCv[i] != prevV) {
                        var converted = ToHiragana(splitCv[i]);
                        phonemes.Add(TryVcv(prevV, converted, syllable.vowelTone));
                        prevV = splitCv[i].Last<char>().ToString();
                    }
                }
            }

            return phonemes;
        }

        protected override List<string> ProcessEnding(Ending ending) {
            var prevV = ending.prevV;
            var cc = ending.cc;
            var phonemes = new List<string>();

            // Check CCs for special clusters
            var adjustedCC = new List<string>();
            for (var i = 0; i < cc.Length; i++) {
                if (i == cc.Length - 1) {
                    adjustedCC.Add(cc[i]);
                } else {
                    if (cc[i] == cc[i + 1]) {
                        adjustedCC.Add(cc[i]);
                        i++;
                        continue;
                    }
                    var diphone = $"{cc[i]}{cc[i + 1]}";
                    if (SpecialClusters.Contains(diphone)) {
                        adjustedCC.Add(diphone);
                        i++;
                    } else {
                        adjustedCC.Add(cc[i]);
                    }
                }
            }
            cc = adjustedCC.ToArray();

            var usingVC = false;
            // Convert to hiragana
            for (var i = 0; i < cc.Length; i++) {
                var symbol = cc[i];

                if (i == 0) {
                    (var hasVc, var vcPhonemes) = HasVc(prevV, symbol, ending.tone, cc.Length+1);
                    usingVC = hasVc;
                    phonemes.AddRange(vcPhonemes);
                    if (usingVC) {
                        continue;
                    }
                }

                var solo = SoloConsonant[symbol];
                if (!usingVC) {
                    solo = TryVcv(prevV, solo, ending.tone);
                } else {
                    usingVC = false;
                    solo = FixCv(solo, ending.tone);
                }
                
                if (HasOto(solo, ending.tone)) {
                    phonemes.Add(solo);
                } else if (ConditionalAlt.ContainsKey(solo)) {
                    solo = ConditionalAlt[solo];
                    if (!usingVC) {
                        solo = TryVcv(prevV, solo, ending.tone);
                    } else {
                        solo = FixCv(solo, ending.tone);
                    }
                    phonemes.Add(solo);
                }
                prevV = WanaKana.ToRomaji(solo).Last<char>().ToString();
            }

            return phonemes;
        }
        
        private (bool, string[]) HasVc(string vowel, string cons, int tone, int cc) {
            if (vowel == "" || vowel == "-") {
                return (false, new string[0]);
            }

            var phonemes = new List<string>();
            if (cons == "r") {
                cons = "w";
            } else if (cons == "l") {
                cons = "r";
            } else if (cons == "ly") {
                cons = "ry";
            }

            var vc = $"{vowel} {cons}";
            var altVc = $"{vowel} {cons[0]}";

            if (HasOto(vc, tone)) {
                phonemes.Add(vc);
            } else if (HasOto(altVc, tone)) {
                phonemes.Add(altVc);
            }

            if (affricates.Contains(cons) && cc > 1) {
                phonemes.Add(FixCv(SoloConsonant[cons], tone));
            }

            return (phonemes.Count > 0, phonemes.ToArray());
        }

        private string TryVcv(string vowel, string cv, int tone) {
            var vcv = $"{vowel} {cv}";
            return HasOto(vcv, tone) ? vcv : FixCv(cv, tone);
        }

        private string FixCv(string cv, int tone) {
            var alt = $"- {cv}";
            return HasOto(cv, tone) ? cv : HasOto(alt, tone) ? alt : cv;
        }

        private string ToHiragana(string romaji) {
            var hiragana = WanaKana.ToHiragana(romaji);
            hiragana = hiragana.Replace("ゔ", "ヴ");
            return hiragana;
        }
    }
}
