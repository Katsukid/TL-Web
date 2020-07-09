var updatecartitemincart = {
     init: function () {
          updatecartitemincart.responseEvents();
     },
     responseEvents: function () {
          $('#btn_update_item').off('click').on('click', function (e) {
               e.preventDefault();
               var form = $('form#form_cart').serialize();
               $.ajax({
                    type: 'POST',
                    url: '/Cart/UpdateCartAll',
                    data: form,
                    dataType: 'json',
                    success: function (partialViewData) {
                         alert("Cap nhat gio hang thanh cong");
                         $('#cart_content').html(partialViewData.stringView);
                         // Cap nhat hien thi so hang trong gio
                         $.ajax({
                              type: 'POST',
                              url: '/Cart/Cart',
                              data: null,
                              dataType: 'json',
                              success: function (cart) {
                                   $('#cart-icon').text(cart.totalquantity);
                              }
                         });
                    }
               });
               return false;
          });
     }
};



updatecartitemincart.init();
var deletecartitemincart = {
     init: function () {
          deletecartitemincart.responseEvents();
     },
     responseEvents: function () {
          $('.btn_delete_item').off('click').on('click', function (e) {
               e.preventDefault();
               var btn = $(this);
               var id = btn.data('id');
               var listShippingType = $('#listShippingType').val();
               $.ajax({
                    type: 'POST',
                    url: '/Cart/DeleteCartItem',
                    data: { ItemID: id, listShippingType: listShippingType },
                    dataType: 'json',
                    success: function (partialViewData) {
                         alert("Da xoa mat tieu");
                         $('#cart_content').html(partialViewData.stringView);
                         // Cap nhat hien thi so hang trong gio
                         $.ajax({
                              type: 'POST',
                              url: '/Cart/Cart',
                              data: null,
                              dataType: 'json',
                              success: function (cart) {
                                   $('#cart-icon').text(cart.totalquantity);
                              }
                         });
                    }
               });
               return false;
          });
     }
};
deletecartitemincart.init();


var coupon = {
     intit: function () {
          coupon.responseEvents();
     },
     responseEvents: function () {
          $('#submit-coupon').off('click').on('click', function (e) {
               e.preventDefault();
               var data = $('form#form_coupon').serialize();
               $.ajax({
                    type: 'POST',
                    url: 'Cart/Coupon',
                    data: data,
                    dataType: 'json',
                    success: function (coupon) {
                         if (coupon.status == false) {
                              alert("Có gì đó sai sai! Mã khuyến mãi không đúng!");
                              $('#discount').text(coupon.discount + ' VNĐ');
                         }
                         else {
                              $('#discount').text(coupon.discount + ' VNĐ');
                         }
                         return false;
                    }
               })
          })
     }
};
coupon.intit();


var addcartitemincart = {
     init: function () {
          addcartitemincart.responseEvents();
     },
     responseEvents: function () {
          $('.btn-add-cart').off('click').on('click', function (e) {
               e.preventDefault();
               var btn = $(this);
               var ItemID = btn.data('itemid');
               var listShippingType = $('#listShippingType').val();
               $.ajax({
                    type: 'POST',
                    url: '/Cart/AddCartItemInCart',
                    data: { ItemID: ItemID, listShippingType: listShippingType},
                    dataType: 'json',
                    success: function (partialViewData) {
                         if (partialViewData.status == true) {
                              alert("Đã thêm thành công rồi nè!");
                              $('#cart_content').html(partialViewData.stringView);
                              $.ajax({
                                   type: 'POST',
                                   url: '/Cart/Cart',
                                   data: null,
                                   dataType: 'json',
                                   success: function (cart) {
                                        $('#cart-icon').text(cart.totalquantity);
                                   }
                              });
                         }
                         else {
                              alert(partialViewData.stringView);
                         }
                         
                    }
               });
               return false;
          });
     }
};



