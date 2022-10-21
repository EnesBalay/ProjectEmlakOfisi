function sleep(ms) {
    return new Promise(resolve => setTimeout(resolve, ms));
}

function AreYouSureDeleteAdvert(x) {
    var advertID = parseInt(x.parentNode.parentNode.childNodes[1].textContent);
    var advertName = x.parentNode.parentNode.childNodes[3].textContent;
    const wrapper = document.createElement('div');
    wrapper.innerHTML = "<span style='font-weight:bold;color:red;'>" + advertName + "</span> başlıklı ilanı silmek istediğinize emin misiniz ?";
    swal({
        title: "Silme İşlemi",
        content: wrapper,
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                swal("İşlem başarılı ilanınız 3 saniye sonra silinecektir!. Lütfen bekleyiniz.", {
                    icon: "success",
                    buttons:false
                });
                setTimeout(() => { window.location.href = "/Advert/DeleteAdvert/" + advertID;}, 3000);
               
                    
            } else {
                swal("İşlem iptal edildi ilanınız güvende!", {
                    icon:"info"
                });
            }
        });
}
function AreYouSureDeleteUser(x) {
    var userID = parseInt(x.parentNode.parentNode.childNodes[1].textContent);
    var userName = x.parentElement.parentElement.children[2].textContent;
    const wrapper = document.createElement('div');
    wrapper.innerHTML = "<span style='font-weight:bold;color:red;'>" + userName + "</span> adlı firmayı silmek istediğinize emin misiniz ?";
    swal({
        title: "Silme İşlemi",
        content: wrapper,
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                swal("İşlem başarılı emlakçı 3 saniye sonra silinecektir!. Lütfen bekleyiniz.", {
                    icon: "success",
                    buttons:false
                });
                setTimeout(() => { window.location.href = "/Admin/User/UserDelete/" + userID; }, 3000);
               
                    
            } else {
                swal("İşlem iptal edildi emlakçı güvende!", {
                    icon:"info"
                });
            }
        });
}

$("input[data-type='currency']").on({
    keyup: function () {
        formatCurrency($(this));
    },
    blur: function () {
        formatCurrency($(this), "blur");
    }
});

//Money Formatting START
function formatNumber(n) {
    // format number 1000000 to 1,234,567
    return n.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ".")
}


function formatCurrency(input, blur) {
    // appends $ to value, validates decimal side
    // and puts cursor back in right position.

    // get input value
    var input_val = input.val();

    // don't validate empty input
    if (input_val === "") { return; }

    // original length
    var original_len = input_val.length;

    // initial caret position 
    var caret_pos = input.prop("selectionStart");

    // check for decimal
    if (input_val.indexOf(",") >= 0) {

        // get position of first decimal
        // this prevents multiple decimals from
        // being entered
        var decimal_pos = input_val.indexOf(",");

        // split number by decimal point
        var left_side = input_val.substring(0, decimal_pos);
        var right_side = input_val.substring(decimal_pos);

        // add commas to left side of number
        left_side = formatNumber(left_side);

        // validate right side
        right_side = formatNumber(right_side);

        // On blur make sure 2 numbers after decimal
        if (blur === "blur") {
            right_side += "00";
        }

        // Limit decimal to only 2 digits
        right_side = right_side.substring(0, 2);

        // join number by .
        input_val = left_side + "," + right_side;

    } else {
        // no decimal entered
        // add commas to number
        // remove all non-digits
        input_val = formatNumber(input_val);

        // final formatting
        if (blur === "blur") {
            input_val += ",00";
        }
    }

    // send updated string to input
    input.val(input_val);

    // put caret back in the right position
    var updated_len = input_val.length;
    caret_pos = updated_len - original_len + caret_pos;
    input[0].setSelectionRange(caret_pos, caret_pos);
}
//Money Formatting END