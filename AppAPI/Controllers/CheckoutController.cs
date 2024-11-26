using Microsoft.AspNetCore.Mvc;
using Net.payOS.Types;
using Net.payOS;
using Newtonsoft.Json;

namespace AppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly PayOS _payOS;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CheckoutController(PayOS payOS, IHttpContextAccessor httpContextAccessor)
        {
            _payOS = payOS;
            _httpContextAccessor = httpContextAccessor;
        }

        public class PaymentRequest
        {
            public int OrderCode { get; set; }
            public List<ItemRequest> Items { get; set; }
            public int TotalAmount { get; set; }
            public string Description { get; set; }
        }

        public class ItemRequest
        {
            public string Name { get; set; }
            public int Quantity { get; set; }
            public int Price { get; set; }
        }

        

        [HttpPost("create-payment-link")]
        public async Task<IActionResult> Checkout([FromBody] PaymentRequest payload)
        {
            try
            {
                // Log dữ liệu nhận từ frontend
                Console.WriteLine("Dữ liệu nhận từ FE: " + JsonConvert.SerializeObject(payload));

                // Tạo mã đơn hàng từ FE
                int orderCode = payload.OrderCode;

                // Lấy danh sách item và tổng tiền từ payload
                List<ItemData> items = payload.Items
                    .Select(i => new ItemData(i.Name, i.Quantity, i.Price))
                    .ToList();

                // Lấy URL gốc từ HTTP request
                var request = _httpContextAccessor.HttpContext.Request;
                var baseUrl = $"{request.Scheme}://{request.Host}";

                // Dữ liệu thanh toán
                PaymentData paymentData = new PaymentData(
                    orderCode,
                    payload.TotalAmount,
                    payload.Description,
                    items,
                    "/cancel",  // Trang Cancel (Frontend sẽ xử lý quay lại trang trước đó)
                    "/success"  // Trang Success (Frontend sẽ chuyển hướng về trang chủ)
                );

                // Tạo link thanh toán thông qua PayOS
                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                // Trả về link thanh toán dưới dạng JSON
                return Ok(new
                {
                    success = true,
                    checkoutUrl = createPayment.checkoutUrl
                });
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                // Trả về lỗi nếu có vấn đề xảy ra
                return BadRequest(new
                {
                    success = false,
                    message = "Đã xảy ra lỗi khi tạo link thanh toán.",
                    error = exception.Message
                });
            }
        }
    }
}
