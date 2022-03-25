using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChannelEngine.Integration.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BillingAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public string HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryIso { get; set; }
        public string Original { get; set; }
    }

    public class ShippingAddress
    {
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string Gender { get; set; }
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StreetName { get; set; }
        public string HouseNr { get; set; }
        public string HouseNrAddition { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string CountryIso { get; set; }
        public string Original { get; set; }
    }

    public class StockLocation
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ExtraData
    {
        public string Key { get; set; }
        public string Value { get; set; }
        public string additionalProp1 { get; set; }
        public string additionalProp2 { get; set; }
        public string additionalProp3 { get; set; }
    }

    public class Line
    {
        public string Status { get; set; }
        public bool IsFulfillmentByMarketplace { get; set; }
        public string Gtin { get; set; }
        public string Description { get; set; }
        public StockLocation StockLocation { get; set; }
        public string UnitVat { get; set; }
        public string LineTotalInclVat { get; set; }
        public string LineVat { get; set; }
        public string OriginalUnitPriceInclVat { get; set; }
        public string OriginalUnitVat { get; set; }
        public string OriginalLineTotalInclVat { get; set; }
        public string OriginalLineVat { get; set; }
        public string OriginalFeeFixed { get; set; }
        public string BundleProductMerchantProductNo { get; set; }
        public string JurisCode { get; set; }
        public string JurisName { get; set; }
        public string VatRate { get; set; }
        public List<ExtraData> ExtraData { get; set; }
        public string ChannelProductNo { get; set; }
        public string MerchantProductNo { get; set; }
        public int Quantity { get; set; }
        public int CancellationRequestedQuantity { get; set; }
        public string UnitPriceInclVat { get; set; }
        public string FeeFixed { get; set; }
        public string FeeRate { get; set; }
        public string Condition { get; set; }
        public DateTime ExpectedDeliveryDate { get; set; }
    }

    public class Content
    {
        public int Id { get; set; }
        public string ChannelName { get; set; }
        public int ChannelId { get; set; }
        public string GlobalChannelName { get; set; }
        public int GlobalChannelId { get; set; }
        public string ChannelOrderSupport { get; set; }
        public string ChannelOrderNo { get; set; }
        public string MerchantOrderNo { get; set; }
        public string Status { get; set; }
        public bool IsBusinessOrder { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string MerchantComment { get; set; }
        public BillingAddress BillingAddress { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        public string SubTotalInclVat { get; set; }
        public string SubTotalVat { get; set; }
        public string ShippingCostsVat { get; set; }
        public string TotalInclVat { get; set; }
        public string TotalVat { get; set; }
        public string OriginalSubTotalInclVat { get; set; }
        public string OriginalSubTotalVat { get; set; }
        public string OriginalShippingCostsInclVat { get; set; }
        public string OriginalShippingCostsVat { get; set; }
        public string OriginalTotalInclVat { get; set; }
        public string OriginalTotalVat { get; set; }
        public List<Line> Lines { get; set; }
        public string ShippingCostsInclVat { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CompanyRegistrationNo { get; set; }
        public string VatNo { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentReferenceNo { get; set; }
        public string CurrencyCode { get; set; }
        public DateTime OrderDate { get; set; }
        public string ChannelCustomerNo { get; set; }
        public ExtraData ExtraData { get; set; }
    }

    public class ValidationErrors
    {
        public List<string> additionalProp1 { get; set; }
        public List<string> additionalProp2 { get; set; }
        public List<string> additionalProp3 { get; set; }
    }

    public class OrderIntegrationModel
    {
        public List<Content> Content { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int StatusCode { get; set; }
        public int? LogId { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public ValidationErrors ValidationErrors { get; set; }
    }


}
