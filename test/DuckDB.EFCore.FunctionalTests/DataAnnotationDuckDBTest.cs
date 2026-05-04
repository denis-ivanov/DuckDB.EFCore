using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.TestUtilities;
using Xunit;
using Xunit.Abstractions;

namespace Microsoft.EntityFrameworkCore;

public class DataAnnotationDuckDBTest : DataAnnotationRelationalTestBase<DataAnnotationDuckDBTest.DataAnnotationDuckDBFixture>
{
    public DataAnnotationDuckDBTest(DataAnnotationDuckDBFixture fixture, ITestOutputHelper testOutputHelper) : base(fixture)
    {
        Fixture.TestSqlLoggerFactory.Clear();
        Fixture.TestSqlLoggerFactory.SetTestOutputHelper(testOutputHelper);
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Annotation_in_derived_class_when_base_class_processed_after_derived_class()
    {
        base.Annotation_in_derived_class_when_base_class_processed_after_derived_class();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Attribute_set_shadow_FK_name_is_preserved_with_HasPrincipalKey()
    {
        base.Attribute_set_shadow_FK_name_is_preserved_with_HasPrincipalKey();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task ConcurrencyCheckAttribute_throws_if_value_in_database_changed()
    {
        await base.ConcurrencyCheckAttribute_throws_if_value_in_database_changed();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKey_to_ForeignKey_on_many_to_many()
    {
        base.ForeignKey_to_ForeignKey_on_many_to_many();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task Table_can_configure_TPT_with_Owned()
    {
        await base.Table_can_configure_TPT_with_Owned();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override async Task DatabaseGeneratedAttribute_autogenerates_values_when_set_to_identity()
    {
        await base.DatabaseGeneratedAttribute_autogenerates_values_when_set_to_identity();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override IModel DatabaseGeneratedOption_configures_the_property_correctly()
    {
        return base.DatabaseGeneratedOption_configures_the_property_correctly();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override IModel DatabaseGeneratedOption_Identity_does_not_throw_on_noninteger_properties()
    {
        return base.DatabaseGeneratedOption_Identity_does_not_throw_on_noninteger_properties();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override ModelBuilder Default_length_for_key_string_column()
    {
        return base.Default_length_for_key_string_column();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Duplicate_column_order_is_ignored()
    {
        base.Duplicate_column_order_is_ignored();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Explicit_configuration_on_derived_type_or_base_type_is_last_one_wins()
    {
        base.Explicit_configuration_on_derived_type_or_base_type_is_last_one_wins();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Explicit_configuration_on_derived_type_overrides_annotation_on_mapped_base_type()
    {
        base.Explicit_configuration_on_derived_type_overrides_annotation_on_mapped_base_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Explicit_configuration_on_derived_type_overrides_annotation_on_unmapped_base_type()
    {
        base.Explicit_configuration_on_derived_type_overrides_annotation_on_unmapped_base_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override IModel Field_annotations_are_enabled()
    {
        return base.Field_annotations_are_enabled();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Fluent_API_relationship_throws_for_Keyless_attribute()
    {
        base.Fluent_API_relationship_throws_for_Keyless_attribute();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKey_to_ForeignKey()
    {
        base.ForeignKey_to_ForeignKey();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKey_to_ForeignKey_same_name()
    {
        base.ForeignKey_to_ForeignKey_same_name();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKey_to_ForeignKey_same_name_one_shadow()
    {
        base.ForeignKey_to_ForeignKey_same_name_one_shadow();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKey_to_nothing()
    {
        base.ForeignKey_to_nothing();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKeyAttribute_configures_relationships_when_inverse_on_derived()
    {
        base.ForeignKeyAttribute_configures_relationships_when_inverse_on_derived();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKeyAttribute_configures_two_self_referencing_relationships()
    {
        base.ForeignKeyAttribute_configures_two_self_referencing_relationships();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKeyAttribute_creates_two_relationships_if_applied_on_navigation_and_property_on_different_sides_and_values_do_not_match()
    {
        base.ForeignKeyAttribute_creates_two_relationships_if_applied_on_navigation_and_property_on_different_sides_and_values_do_not_match();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKeyAttribute_creates_two_relationships_if_applied_on_navigations_on_both_sides_and_values_do_not_match()
    {
        base.ForeignKeyAttribute_creates_two_relationships_if_applied_on_navigations_on_both_sides_and_values_do_not_match();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKeyAttribute_creates_two_relationships_if_applied_on_property_on_both_side()
    {
        base.ForeignKeyAttribute_creates_two_relationships_if_applied_on_property_on_both_side();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKeyAttribute_throws_if_applied_on_both_navigations_connected_by_inverse_property_but_values_do_not_match()
    {
        base.ForeignKeyAttribute_throws_if_applied_on_both_navigations_connected_by_inverse_property_but_values_do_not_match();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKeyAttribute_throws_if_applied_on_property_on_both_side_but_navigations_are_connected_by_inverse_property()
    {
        base.ForeignKeyAttribute_throws_if_applied_on_property_on_both_side_but_navigations_are_connected_by_inverse_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void ForeignKeyAttribute_throws_if_applied_on_two_relationships_targetting_the_same_property()
    {
        base.ForeignKeyAttribute_throws_if_applied_on_two_relationships_targetting_the_same_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Inverse_and_self_ref_ForeignKey()
    {
        base.Inverse_and_self_ref_ForeignKey();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InverseProperty_with_case_sensitive_clr_property()
    {
        base.InverseProperty_with_case_sensitive_clr_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InverseProperty_with_potentially_ambigous_derived_types()
    {
        base.InverseProperty_with_potentially_ambigous_derived_types();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_from_ignored_base_can_be_ignored_to_remove_ambiguity()
    {
        base.InversePropertyAttribute_from_ignored_base_can_be_ignored_to_remove_ambiguity();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_from_ignored_base_causes_ambiguity()
    {
        base.InversePropertyAttribute_from_ignored_base_causes_ambiguity();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_is_noop_in_unambiguous_models()
    {
        base.InversePropertyAttribute_is_noop_in_unambiguous_models();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_pointing_to_same_nav_on_base_causes_ambiguity()
    {
        base.InversePropertyAttribute_pointing_to_same_nav_on_base_causes_ambiguity();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_pointing_to_same_nav_on_base_with_one_ignored()
    {
        base.InversePropertyAttribute_pointing_to_same_nav_on_base_with_one_ignored();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_pointing_to_same_skip_nav_on_base_causes_ambiguity()
    {
        base.InversePropertyAttribute_pointing_to_same_skip_nav_on_base_causes_ambiguity();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_removes_ambiguity()
    {
        base.InversePropertyAttribute_removes_ambiguity();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_removes_ambiguity_from_the_ambiguous_end()
    {
        base.InversePropertyAttribute_removes_ambiguity_from_the_ambiguous_end();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_removes_ambiguity_when_combined_with_other_attributes()
    {
        base.InversePropertyAttribute_removes_ambiguity_when_combined_with_other_attributes();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task MaxLengthAttribute_throws_while_inserting_value_longer_than_max_length()
    {
        return base.MaxLengthAttribute_throws_while_inserting_value_longer_than_max_length();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_removes_ambiguity_with_base_type()
    {
        base.InversePropertyAttribute_removes_ambiguity_with_base_type();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_removes_ambiguity_with_base_type_bidirectional()
    {
        base.InversePropertyAttribute_removes_ambiguity_with_base_type_bidirectional();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void InversePropertyAttribute_removes_ambiguity_with_base_type_ignored()
    {
        base.InversePropertyAttribute_removes_ambiguity_with_base_type_ignored();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override IModel Key_and_column_work_together()
    {
        return base.Key_and_column_work_together();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override IModel Key_and_MaxLength_64_produce_nvarchar_64()
    {
        return base.Key_and_MaxLength_64_produce_nvarchar_64();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Key_fluent_api_and_keyless_attribute_do_not_cause_warning()
    {
        base.Key_fluent_api_and_keyless_attribute_do_not_cause_warning();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Key_from_base_type_is_recognized()
    {
        base.Key_from_base_type_is_recognized();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Key_from_base_type_is_recognized_if_base_discovered_first()
    {
        base.Key_from_base_type_is_recognized_if_base_discovered_first();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Key_on_nav_prop_is_ignored()
    {
        base.Key_on_nav_prop_is_ignored();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override ModelBuilder Key_property_is_not_used_for_FK_when_set_by_annotation()
    {
        return base.Key_property_is_not_used_for_FK_when_set_by_annotation();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Key_from_base_type_is_recognized_if_discovered_through_relationship()
    {
        base.Key_from_base_type_is_recognized_if_discovered_through_relationship();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override ModelBuilder Key_specified_on_multiple_properties_can_be_overridden()
    {
        return base.Key_specified_on_multiple_properties_can_be_overridden();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Keyless_and_key_attributes_which_conflict_cause_warning()
    {
        base.Keyless_and_key_attributes_which_conflict_cause_warning();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Keyless_fluent_api_and_key_attribute_do_not_cause_warning()
    {
        base.Keyless_fluent_api_and_key_attribute_do_not_cause_warning();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void MaxLength_with_length_takes_precedence_over_StringLength()
    {
        base.MaxLength_with_length_takes_precedence_over_StringLength();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Multiple_self_ref_ForeignKey_and_Inverse()
    {
        base.Multiple_self_ref_ForeignKey_and_Inverse();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Multiple_self_ref_ForeignKeys_on_navigations()
    {
        base.Multiple_self_ref_ForeignKeys_on_navigations();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Multiple_self_ref_ForeignKeys_on_properties()
    {
        base.Multiple_self_ref_ForeignKeys_on_properties();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override IModel Non_public_annotations_are_enabled()
    {
        return base.Non_public_annotations_are_enabled();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Nothing_to_ForeignKey()
    {
        base.Nothing_to_ForeignKey();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Nothing_to_Required_and_ForeignKey()
    {
        base.Nothing_to_Required_and_ForeignKey();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_on_abstract_base_class_property_ignores_it()
    {
        base.NotMapped_on_abstract_base_class_property_ignores_it();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_on_base_class_property_and_overridden_property_ignores_them()
    {
        base.NotMapped_on_base_class_property_and_overridden_property_ignores_them();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_on_base_class_property_discovered_through_navigation_ignores_it()
    {
        base.NotMapped_on_base_class_property_discovered_through_navigation_ignores_it();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_on_base_class_property_ignores_it()
    {
        base.NotMapped_on_base_class_property_ignores_it();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_on_new_property_with_same_name_as_in_unmapped_base_class_ignores_it()
    {
        base.NotMapped_on_new_property_with_same_name_as_in_unmapped_base_class_ignores_it();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_on_overridden_property_is_ignored()
    {
        base.NotMapped_on_overridden_property_is_ignored();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_on_unmapped_base_class_property_and_overridden_property_ignores_it()
    {
        base.NotMapped_on_unmapped_base_class_property_and_overridden_property_ignores_it();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_on_unmapped_base_class_property_ignores_it()
    {
        base.NotMapped_on_unmapped_base_class_property_ignores_it();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_on_unmapped_derived_property_ignores_it()
    {
        base.NotMapped_on_unmapped_derived_property_ignores_it();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMapped_should_propagate_down_inheritance_hierarchy()
    {
        base.NotMapped_should_propagate_down_inheritance_hierarchy();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMappedAttribute_ignores_entityType()
    {
        base.NotMappedAttribute_ignores_entityType();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMappedAttribute_ignores_explicit_interface_implementation_property()
    {
        base.NotMappedAttribute_ignores_explicit_interface_implementation_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMappedAttribute_ignores_navigation()
    {
        base.NotMappedAttribute_ignores_navigation();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMappedAttribute_ignores_property()
    {
        base.NotMappedAttribute_ignores_property();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMappedAttribute_removes_ambiguity_in_relationship_building()
    {
        base.NotMappedAttribute_removes_ambiguity_in_relationship_building();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void NotMappedAttribute_removes_ambiguity_in_relationship_building_with_base()
    {
        base.NotMappedAttribute_removes_ambiguity_in_relationship_building_with_base();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void OwnedEntityTypeAttribute_configures_all_references_as_owned()
    {
        base.OwnedEntityTypeAttribute_configures_all_references_as_owned();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void OwnedEntityTypeAttribute_configures_one_reference_as_owned()
    {
        base.OwnedEntityTypeAttribute_configures_one_reference_as_owned();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void PrecisionAttribute_sets_precision_for_properties_and_fields()
    {
        base.PrecisionAttribute_sets_precision_for_properties_and_fields();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Required_and_ForeignKey_to_ForeignKey_can_be_overridden()
    {
        base.Required_and_ForeignKey_to_ForeignKey_can_be_overridden();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Required_and_ForeignKey_to_nothing()
    {
        base.Required_and_ForeignKey_to_nothing();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Required_and_ForeignKey_to_Required()
    {
        base.Required_and_ForeignKey_to_Required();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Required_and_ForeignKey_to_Required_and_ForeignKey()
    {
        base.Required_and_ForeignKey_to_Required_and_ForeignKey();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Required_and_ForeignKey_to_Required_and_ForeignKey_can_be_overridden()
    {
        base.Required_and_ForeignKey_to_Required_and_ForeignKey_can_be_overridden();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Required_to_Nothing()
    {
        base.Required_to_Nothing();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Required_to_Nothing_inverted()
    {
        base.Required_to_Nothing_inverted();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Required_to_Required_and_ForeignKey()
    {
        base.Required_to_Required_and_ForeignKey();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task RequiredAttribute_for_navigation_throws_while_inserting_null_value()
    {
        return base.RequiredAttribute_for_navigation_throws_while_inserting_null_value();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task RequiredAttribute_for_property_throws_while_inserting_null_value()
    {
        return base.RequiredAttribute_for_property_throws_while_inserting_null_value();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void Shared_ForeignKey_to_different_principals()
    {
        base.Shared_ForeignKey_to_different_principals();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void StringLength_with_value_takes_precedence_over_MaxLength()
    {
        base.StringLength_with_value_takes_precedence_over_MaxLength();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task StringLengthAttribute_throws_while_inserting_value_longer_than_max_length()
    {
        return base.StringLengthAttribute_throws_while_inserting_value_longer_than_max_length();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override IModel TableNameAttribute_affects_table_name_in_TPH()
    {
        return base.TableNameAttribute_affects_table_name_in_TPH();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override IModel Timestamp_takes_precedence_over_MaxLength()
    {
        return base.Timestamp_takes_precedence_over_MaxLength();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override Task TimestampAttribute_throws_if_value_in_database_changed()
    {
        return base.TimestampAttribute_throws_if_value_in_database_changed();
    }

    [ConditionalFact(Skip = DuckDBSkipReasons.Tbd)]
    public override void UnicodeAttribute_sets_unicode_for_properties_and_fields()
    {
        base.UnicodeAttribute_sets_unicode_for_properties_and_fields();
    }

    protected override void UseTransaction(DatabaseFacade facade, IDbContextTransaction transaction)
        => facade.UseTransaction(transaction.GetDbTransaction());

    protected override TestHelpers TestHelpers
        => DuckDBTestHelpers.Instance;
    
    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);

    public class DataAnnotationDuckDBFixture : DataAnnotationRelationalFixtureBase, ITestSqlLoggerFactory
    {
        protected override ITestStoreFactory TestStoreFactory
            => DuckDBTestStoreFactory.Instance;

        public TestSqlLoggerFactory TestSqlLoggerFactory
            => (TestSqlLoggerFactory)ListLoggerFactory;
    }
}