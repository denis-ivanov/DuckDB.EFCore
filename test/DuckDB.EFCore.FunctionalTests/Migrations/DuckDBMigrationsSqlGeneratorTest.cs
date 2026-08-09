using DuckDB.EFCore.Infrastructure;
using DuckDB.EFCore.NTS.Extensions;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Microsoft.EntityFrameworkCore.Migrations;

public class DuckDBMigrationsSqlGeneratorTest : MigrationsSqlGeneratorTestBase
{
    public DuckDBMigrationsSqlGeneratorTest()
        : base(DuckDBTestHelpers.Instance,
            new ServiceCollection().AddEntityFrameworkDuckDBNetTopologySuite(),
            DuckDBTestHelpers.Instance.AddProviderOptions(
                ((IRelationalDbContextOptionsBuilderInfrastructure)
                    new DuckDBDbContextOptionsBuilder(new DbContextOptionsBuilder()).UseNetTopologySuite())
                .OptionsBuilder).Options)
    {
    }

    protected override string GetGeometryCollectionStoreType()
    {
        return "GEOMETRYCOLLECTION";
    }

    public override void AddColumnOperation_without_column_type()
    {
        base.AddColumnOperation_without_column_type();

        AssertSql(
            """
            ALTER TABLE "People" ADD "Alias" VARCHAR NOT NULL;
            """);
    }

    public override void AddColumnOperation_with_unicode_overridden()
    {
        base.AddColumnOperation_with_unicode_overridden();

        AssertSql(
            """
            ALTER TABLE "Person" ADD "Name" VARCHAR NULL;
            """);
    }

    public override void AddColumnOperation_with_unicode_no_model()
    {
        base.AddColumnOperation_with_unicode_no_model();
        
        AssertSql(
            """
            ALTER TABLE "Person" ADD "Name" VARCHAR NULL;
            """);
    }

    public override void AddColumnOperation_with_fixed_length_no_model()
    {
        base.AddColumnOperation_with_fixed_length_no_model();

        AssertSql(
            """
            ALTER TABLE "Person" ADD "Name" VARCHAR NULL;
            """);
    }

    public override void AddColumnOperation_with_maxLength_overridden()
    {
        base.AddColumnOperation_with_maxLength_overridden();
        
        AssertSql(
            """
            ALTER TABLE "Person" ADD "Name" VARCHAR NULL;
            """);
    }

    public override void AddColumnOperation_with_maxLength_no_model()
    {
        base.AddColumnOperation_with_maxLength_no_model();
        
        AssertSql(
            """
            ALTER TABLE "Person" ADD "Name" VARCHAR NULL;
            """);
    }

    public override void AddColumnOperation_with_precision_and_scale_overridden()
    {
        base.AddColumnOperation_with_precision_and_scale_overridden();

        AssertSql(
            """
            ALTER TABLE "Person" ADD "Pi" DECIMAL(15,10) NOT NULL;
            """);
    }

    public override void AddColumnOperation_with_precision_and_scale_no_model()
    {
        base.AddColumnOperation_with_precision_and_scale_no_model();

        AssertSql(
            """
            ALTER TABLE "Person" ADD "Pi" DECIMAL(20,7) NOT NULL;
            """);
    }

    public override void AddForeignKeyOperation_without_principal_columns()
    {
        base.AddForeignKeyOperation_without_principal_columns();
    }

    public override void RenameTableOperation_legacy()
    {
        base.RenameTableOperation_legacy();
        
        AssertSql(
            """
            ALTER TABLE dbo."People" RENAME TO "Person"
            """);
    }

    public override void RenameTableOperation()
    {
        base.RenameTableOperation();

        AssertSql(
            """
            ALTER TABLE dbo."People" RENAME TO dbo."Person"
            """);
    }

    public override void AlterColumnOperation_without_column_type()
    {
        base.AlterColumnOperation_without_column_type();
    }

    public override void InsertDataOperation_all_args_spatial()
    {
        base.InsertDataOperation_all_args_spatial();
        
        AssertSql(
            """
            INSERT INTO dbo."People" ("Id", "Full Name", "Geometry")
            VALUES (0, NULL, NULL);
            INSERT INTO dbo."People" ("Id", "Full Name", "Geometry")
            VALUES (1, 'Daenerys Targaryen', NULL);
            INSERT INTO dbo."People" ("Id", "Full Name", "Geometry")
            VALUES (2, 'John Snow', NULL);
            INSERT INTO dbo."People" ("Id", "Full Name", "Geometry")
            VALUES (3, 'Arya Stark', NULL);
            INSERT INTO dbo."People" ("Id", "Full Name", "Geometry")
            VALUES (4, 'Harry Strickland', NULL);
            INSERT INTO dbo."People" ("Id", "Full Name", "Geometry")
            VALUES (5, 'The Imp', NULL);
            INSERT INTO dbo."People" ("Id", "Full Name", "Geometry")
            VALUES (6, 'The Kingslayer', NULL);
            INSERT INTO dbo."People" ("Id", "Full Name", "Geometry")
            VALUES (7, 'Aemon Targaryen', ST_GeomFromText('GEOMETRYCOLLECTION Z(LINESTRING Z(1.1 2.2 NaN, 2.2 2.2 NaN, 2.2 1.1 NaN, 7.1 7.2 NaN), LINESTRING Z(7.1 7.2 NaN, 20.2 20.2 NaN, 20.2 1.1 NaN, 70.1 70.2 NaN), MULTIPOINT Z((1.1 2.2 NaN), (2.2 2.2 NaN), (2.2 1.1 NaN)), POLYGON Z((1.1 2.2 NaN, 2.2 2.2 NaN, 2.2 1.1 NaN, 1.1 2.2 NaN)), POLYGON Z((10.1 20.2 NaN, 20.2 20.2 NaN, 20.2 10.1 NaN, 10.1 20.2 NaN)), POINT Z(1.1 2.2 3.3), MULTILINESTRING Z((1.1 2.2 NaN, 2.2 2.2 NaN, 2.2 1.1 NaN, 7.1 7.2 NaN), (7.1 7.2 NaN, 20.2 20.2 NaN, 20.2 1.1 NaN, 70.1 70.2 NaN)), MULTIPOLYGON Z(((10.1 20.2 NaN, 20.2 20.2 NaN, 20.2 10.1 NaN, 10.1 20.2 NaN)), ((1.1 2.2 NaN, 2.2 2.2 NaN, 2.2 1.1 NaN, 1.1 2.2 NaN))))', 4326));
            """);
    }

    public override void SqlOperation()
    {
        base.SqlOperation();
    }

    public override void InsertDataOperation_required_args()
    {
        base.InsertDataOperation_required_args();

        AssertSql(
            """
            INSERT INTO dbo."People" ("First Name")
            VALUES ('John');
            """);
    }

    public override void InsertDataOperation_required_args_composite()
    {
        base.InsertDataOperation_required_args_composite();

        AssertSql(
            """
            INSERT INTO dbo."People" ("First Name", "Last Name")
            VALUES ('John', 'Snow');
            """);
    }

    public override void InsertDataOperation_required_args_multiple_rows()
    {
        base.InsertDataOperation_required_args_multiple_rows();

        AssertSql(
            """
            INSERT INTO dbo."People" ("First Name")
            VALUES ('John');
            INSERT INTO dbo."People" ("First Name")
            VALUES ('Daenerys');
            """);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InsertDataOperation_throws_for_unsupported_column_types()
    {
        base.InsertDataOperation_throws_for_unsupported_column_types();
    }

    public override void DeleteDataOperation_all_args()
    {
        base.DeleteDataOperation_all_args();
        
        AssertSql(
            """
            DELETE FROM "People"
            WHERE "First Name" = 'Hodor'
            RETURNING 1;
            DELETE FROM "People"
            WHERE "First Name" = 'Daenerys'
            RETURNING 1;
            DELETE FROM "People"
            WHERE "First Name" = 'John'
            RETURNING 1;
            DELETE FROM "People"
            WHERE "First Name" = 'Arya'
            RETURNING 1;
            DELETE FROM "People"
            WHERE "First Name" = 'Harry'
            RETURNING 1;
            """);
    }

    public override void DeleteDataOperation_all_args_composite()
    {
        base.DeleteDataOperation_all_args_composite();
        
        AssertSql(
            """
            DELETE FROM "People"
            WHERE "First Name" = 'Hodor' AND "Last Name" IS NULL
            RETURNING 1;
            DELETE FROM "People"
            WHERE "First Name" = 'Daenerys' AND "Last Name" = 'Targaryen'
            RETURNING 1;
            DELETE FROM "People"
            WHERE "First Name" = 'John' AND "Last Name" = 'Snow'
            RETURNING 1;
            DELETE FROM "People"
            WHERE "First Name" = 'Arya' AND "Last Name" = 'Stark'
            RETURNING 1;
            DELETE FROM "People"
            WHERE "First Name" = 'Harry' AND "Last Name" = 'Strickland'
            RETURNING 1;
            """);
    }

    public override void DeleteDataOperation_required_args()
    {
        base.DeleteDataOperation_required_args();
        
        AssertSql(
            """
            DELETE FROM "People"
            WHERE "Last Name" = 'Snow'
            RETURNING 1;
            """);
    }

    public override void DeleteDataOperation_required_args_composite()
    {
        base.DeleteDataOperation_required_args_composite();
        
        AssertSql(
            """
            DELETE FROM "People"
            WHERE "First Name" = 'John' AND "Last Name" = 'Snow'
            RETURNING 1;
            """);
    }

    public override void UpdateDataOperation_all_args()
    {
        base.UpdateDataOperation_all_args();
        
        AssertSql(
            """
            UPDATE "People" SET "Birthplace" = 'Winterfell', "House Allegiance" = 'Stark', "Culture" = 'Northmen'
            WHERE "First Name" = 'Hodor'
            RETURNING 1;
            UPDATE "People" SET "Birthplace" = 'Dragonstone', "House Allegiance" = 'Targaryen', "Culture" = 'Valyrian'
            WHERE "First Name" = 'Daenerys'
            RETURNING 1;
            """);
    }

    public override void UpdateDataOperation_all_args_composite()
    {
        base.UpdateDataOperation_all_args_composite();
        
        AssertSql(
            """
            UPDATE "People" SET "House Allegiance" = 'Stark'
            WHERE "First Name" = 'Hodor' AND "Last Name" IS NULL
            RETURNING 1;
            UPDATE "People" SET "House Allegiance" = 'Targaryen'
            WHERE "First Name" = 'Daenerys' AND "Last Name" = 'Targaryen'
            RETURNING 1;
            """);
    }

    public override void UpdateDataOperation_all_args_composite_multi()
    {
        base.UpdateDataOperation_all_args_composite_multi();
        
        AssertSql(
            """
            UPDATE "People" SET "Birthplace" = 'Winterfell', "House Allegiance" = 'Stark', "Culture" = 'Northmen'
            WHERE "First Name" = 'Hodor' AND "Last Name" IS NULL
            RETURNING 1;
            UPDATE "People" SET "Birthplace" = 'Dragonstone', "House Allegiance" = 'Targaryen', "Culture" = 'Valyrian'
            WHERE "First Name" = 'Daenerys' AND "Last Name" = 'Targaryen'
            RETURNING 1;
            """);
    }

    public override void UpdateDataOperation_all_args_multi()
    {
        base.UpdateDataOperation_all_args_multi();
        
        AssertSql(
            """
            UPDATE "People" SET "Birthplace" = 'Dragonstone', "House Allegiance" = 'Targaryen', "Culture" = 'Valyrian'
            WHERE "First Name" = 'Daenerys'
            RETURNING 1;
            """);
    }

    public override void UpdateDataOperation_required_args()
    {
        base.UpdateDataOperation_required_args();
        
        AssertSql(
            """
            UPDATE "People" SET "House Allegiance" = 'Targaryen'
            WHERE "First Name" = 'Daenerys'
            RETURNING 1;
            """);
    }

    public override void UpdateDataOperation_required_args_multiple_rows()
    {
        base.UpdateDataOperation_required_args_multiple_rows();
        
        AssertSql(
            """
            UPDATE "People" SET "House Allegiance" = 'Stark'
            WHERE "First Name" = 'Hodor'
            RETURNING 1;
            UPDATE "People" SET "House Allegiance" = 'Targaryen'
            WHERE "First Name" = 'Daenerys'
            RETURNING 1;
            """);
    }

    public override void UpdateDataOperation_required_args_composite()
    {
        base.UpdateDataOperation_required_args_composite();
        
        AssertSql(
            """
            UPDATE "People" SET "House Allegiance" = 'Targaryen'
            WHERE "First Name" = 'Daenerys' AND "Last Name" = 'Targaryen'
            RETURNING 1;
            """);
    }

    public override void UpdateDataOperation_required_args_composite_multi()
    {
        base.UpdateDataOperation_required_args_composite_multi();
        
        AssertSql(
            """
            UPDATE "People" SET "Birthplace" = 'Dragonstone', "House Allegiance" = 'Targaryen', "Culture" = 'Valyrian'
            WHERE "First Name" = 'Daenerys' AND "Last Name" = 'Targaryen'
            RETURNING 1;
            """);
    }

    public override void UpdateDataOperation_required_args_multi()
    {
        base.UpdateDataOperation_required_args_multi();
        
        AssertSql(
            """
            UPDATE "People" SET "Birthplace" = 'Dragonstone', "House Allegiance" = 'Targaryen', "Culture" = 'Valyrian'
            WHERE "First Name" = 'Daenerys'
            RETURNING 1;
            """);
    }

    public override void DefaultValue_with_line_breaks(bool isUnicode)
    {
        base.DefaultValue_with_line_breaks(isUnicode);
        
        AssertSql(
            """
            CREATE TABLE dbo."TestLineBreaks" (
                "TestDefaultValue" VARCHAR NOT NULL DEFAULT '
            Various Line
            Breaks
            '
            );
            """);
    }

    public override void DefaultValue_with_line_breaks_2(bool isUnicode)
    {
        base.DefaultValue_with_line_breaks_2(isUnicode);
        
         AssertSql(
            """
CREATE TABLE dbo."TestLineBreaks" (
    "TestDefaultValue" VARCHAR NOT NULL DEFAULT '0
1
2
3
4
5
6
7
8
9
10
11
12
13
14
15
16
17
18
19
20
21
22
23
24
25
26
27
28
29
30
31
32
33
34
35
36
37
38
39
40
41
42
43
44
45
46
47
48
49
50
51
52
53
54
55
56
57
58
59
60
61
62
63
64
65
66
67
68
69
70
71
72
73
74
75
76
77
78
79
80
81
82
83
84
85
86
87
88
89
90
91
92
93
94
95
96
97
98
99
100
101
102
103
104
105
106
107
108
109
110
111
112
113
114
115
116
117
118
119
120
121
122
123
124
125
126
127
128
129
130
131
132
133
134
135
136
137
138
139
140
141
142
143
144
145
146
147
148
149
150
151
152
153
154
155
156
157
158
159
160
161
162
163
164
165
166
167
168
169
170
171
172
173
174
175
176
177
178
179
180
181
182
183
184
185
186
187
188
189
190
191
192
193
194
195
196
197
198
199
200
201
202
203
204
205
206
207
208
209
210
211
212
213
214
215
216
217
218
219
220
221
222
223
224
225
226
227
228
229
230
231
232
233
234
235
236
237
238
239
240
241
242
243
244
245
246
247
248
249
250
251
252
253
254
255
256
257
258
259
260
261
262
263
264
265
266
267
268
269
270
271
272
273
274
275
276
277
278
279
280
281
282
283
284
285
286
287
288
289
290
291
292
293
294
295
296
297
298
299
'
);

""");
    }

    public override void Sequence_restart_operation(long? startsAt)
    {
        base.Sequence_restart_operation(startsAt);
    }
}
