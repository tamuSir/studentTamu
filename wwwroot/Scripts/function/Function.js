var deleteId;
var deleteUrl;
var delCallBackfunc;
$(document).ready(function () {
    $('#delete').on('shown.bs.modal', function () {
        $('.btnyes').focus();
        leftright();
    });

    $('#warning').on('shown.bs.modal', function () {
        $('.no').focus();
    });

    $('.amountValidation').keypress(function (e) {
        if (e.which === 46) {
            if ($(this).val().indexOf('.') !== -1) {
                return false;
            }
        }
        if (e.which !== 8 && e.which !== 0 && e.which !== 46 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });

    $(".intergerValidation").keypress(function (e) {
        var key = e.which;
        if (!(key >= 48 && key <= 57))
            e.preventDefault();
    });
});

function datepick(field) {
    $(field).datepicker({ dateFormat: 'yy/mm/dd', maxDate: new Date() }).datepicker('setDate', 'today');
    return true;
}

function AlphabetOnly(evt) {
    var keyCode = (evt.which) ? evt.which : evt.keyCode;
    if ((keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 123) && keyCode != 32) {
        return false;
    }
    return true;
}

function NumberOnly(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}

function keyEvent(foc) {
    if (event.keyCode === 13) {
        $(foc).focus();
        event.preventDefault();
        return false;
    }
}


function DepartmentClear() {
    $('#intDepartmentID').val('');
    $("#strType").val("").change();
    $("#strHOD").val("");
    $("#strRoomno").val("");
    $("#strDepartment").val("");
    $("#IsActive").val('1').change();
    $('#btndept i').attr('class', 'fas fa-save'); 
    $('#iconchange i').attr('class', 'fas fa-save');
    $("#strType").focus();
    $('#btndept').attr('title', 'save');
    $('#iconchange span').text('Add');
}

function RoleAdd() {
    if ($.trim($("#role").val()) === "") {
        toastr.error("Rolename Required", "Alert");
        $("#role").focus();
    }
    else {
        $.ajax({
            type: "POST",
            url: '/Role/Create',
            async: false,
            data: {
                roleid: $.trim($("#roleid").val()),
                role: $.trim($("#role").val()),
                active: $("#active").val() === "1" ? true : false
            },
            dataType: "json",
            success: function (data) {
                if (data === "Inserted") {
                    toastr.success("Added Successfully", "Success");
                }
                else if (data === "Updated") {
                    toastr.success("Updated Successfully", "Success");
                }
                else if (data === "Existed") {
                    toastr.error("This rolename is already exist", "Alert");
                }
                else {
                    toastr.error(data, "Alert");
                }
                RoleGetAll('');
                RoleReset();
            },
            error: function () {
                toastr.error("Server Error", "Alert");
            }
        });
    }
}

function RoleReset() {
    $("#roleid").val('');
    $("#role").val("");
    $('#btnrole i').attr('class', 'fas fa-save');
    $('#Heading i').attr('class', 'fas fa-save');
    $("#active").val("1").change();
    $("#role").focus();
}

function ServiceGroupAdd() {
    if ($.trim($("#strGroupName").val()) === "") {
        $("#strGroupName").css("background", "red");
        setTimeout(function () {
            $('#strGroupName').css('background', 'white').focus();
        }, 1000);
        toastr.error("Groupname Required", "Alert");
        $("#strGroupName").focus();
    }
    else if ($("#strUnder").val() === "" || $("#strUnder").val() === null) {
        $("#strUnder").css("background", "red");
        setTimeout(function () {
            $('#strUnder').css('background', 'white').focus();
        }, 1000);
        toastr.error("Choose under", "Alert");
        $("#strUnder").focus();
    }
    else if ($("#strType").val() === "" || $("#strType").val() === null) {
        $("#strType").css("background", "red");
        setTimeout(function () {
            $('#strType').css('background', 'white').focus();
        }, 1000);
        toastr.error("Choose Type", "Alert");
        $("#strType").focus();
    }
    else {
        $.ajax({
            type: 'POST',
            url: '/ServiceGroup/CreateOrUpdate',
            dataType: 'json',
            async: false,
            data: {
                intSGID: $("#intSGID").val(),
                strGroupName: $("#strGroupName").val(),
                strUnder: $("#strUnder").val(),
                strType: $("#strType").val(),
                IsActive: $("#IsActive").prop("checked") === true ? true : false
            },
            success: function (data) {
                if (data === "Saved Successfully") {
                    toastr.success(data, "Success");
                    ServiceList('');
                    ServiceGroupClear();
                    $("#strGroupName").val("");
                    $("#strGroupName").focus();
                }
                else if (data === "Updated Successfully") {
                    toastr.success(data, "Success");
                    $('#service-group').modal('hide');
                    ServiceList('');
                    ServiceGroupClear();
                }
                else {
                    toastr.error(data, "Alert");
                    $('#service-group').modal('hide');
                }
            },
            error: function () {
                toastr.error("Server Error", "Alert");
            }
        });
    }
}

function ServiceGroupClear() {
    $("#intSGID").val('');
    $("#strGroupName").val("");
    $("#strUnder").val("1").change();
    $("#strType").val("Target").change();
    $("#IsActive").prop("checked", true);
    $('#submit i').attr('class', 'fas fa-save');
    $('#Heading i').attr('class', 'fas fa-save');
    $("#strGroupName").focus();
}

function CategoryAdd() {
    var error = $("#strActive").prop("checked") === true ? true : false;
    var dataObject = {
        strCategory: $("input[name=strCategory]").val(),
        strClass: $("input[name=strClass]").val(),
        strActive: error
    };
    if ($("#strCategory").val() === "") {
        $("#strCategory").css("background", "red");
        setTimeout(function () {
            $('#role').css('background', 'white').focus();
        }, 5000);
        toastr.error("*Category Required", "Alert");
        $("#strCategory").focus();
    }
    else {
        $.ajax({
            url: '/PathoCategory/Create',
            type: "POST",
            data: dataObject,
            dataType: "json",
            success: function (data) {
                if (data === "Added Successfully" || data === "Updated Successfully") {
                    toastr.success(data, "Success");
                }
                else {
                    toastr.error(data, "Alert");
                }
                CategoryReset();
            },
            error: function () {
                toastr.error("Please fill required field", "Alert");
            }
        });
    }
}

function CategoryReset() {
    $("input[name=strCategory]").val("");
    $("input[name=strClass]").val("");
    $("#strActive").prop("checked", true);
}

function leftright() {
    $(document).keydown(function (e) {
        if (e.keyCode === 39) {
            $(".btn-default:focus").next().focus();
        }
        if (e.keyCode === 37) {
            $(".btn-default:focus").prev().focus();
        }
    });
}

function DeleteConfirmation(id, url, callBackFunc) {
    deleteId = id;
    deleteUrl = url;
    delCallBackfunc = callBackFunc;
    $("#delete").modal("show");
}

function ConfirmDelete() {
    $.ajax({
        type: "GET",
        url: deleteUrl,
        data: { id: deleteId },
        success: function (result) {
            if (result === 1) {
                $("#delete").modal("hide");
                toastr.success("Deleted  Successfully", "Success", { timOut: 5000 });
                delCallBackfunc();
            }
            else {
                toastr.warning("This Item is used in another table", "Warning", { timOut: 5000 });
                $("#delete").modal("hide");
                $("#warning").modal("show");
            }
        }
    });
}

function FirstLettercapitalize(id) {
    var str = $(id).val();
    strVal = '';
    str = str.split(' ');
    for (var chr = 0; chr < str.length; chr++) {
        strVal += str[chr].substring(0, 1).toUpperCase() + str[chr].substring(1, str[chr].length) + ' ';
    }
    $(id).val(strVal);
}

function CommonBsGetByAd(GetVal, SetVal) {
    var ToDate = $(GetVal).val();
    $.ajax({
        url: '/Reporting/Billing/GetToBsDate?ToDate=' + ToDate,
        type: 'get',
        async: false,
        success: function (data) {
            var from = data.split("/");
            var yr = calendarFunctions.getNepaliNumber(parseInt(from[0]));
            var mn = calendarFunctions.getNepaliNumber(parseInt(from[1]));
            var da = calendarFunctions.getNepaliNumber(parseInt(from[2]));
            var day = (/^\d$/.test(da)) ? +'0' + '' + da : da;
            var Month = (/^\d$/.test(mn)) ? +'0' + '' + mn : mn;
            var fullDate = day + '/' + Month + '/' + yr;
            $(SetVal).val(fullDate);
        }
    });
}

function CommomAdDateByBs(GetVal, SetVal) {
    var dt = $(GetVal).val();
    var from = dt.split("/");
    var yr = calendarFunctions.getNumberByNepaliNumber(from[0].toString());
    var mn = calendarFunctions.getNumberByNepaliNumber(from[1].toString());
    var da = calendarFunctions.getNumberByNepaliNumber(from[2].toString());
    var day = (/^\d$/.test(da)) ? +'0' + '' + da : da;
    var Month = (/^\d$/.test(mn)) ? +'0' + '' + mn : mn;
    var fullDate = day + '/' + Month + '/' + yr;
    $.ajax({
        url: '/Reporting/Billing/GetToAdDate',
        type: 'get',
        async: false,
        data: { NepaliToDate: fullDate },
        success: function (data) {
            var to = data.split("/");
            var fillDate = to[0] + '/' + to[1] + '/' + to[2];
            $(SetVal).val(fillDate);
        }
    });
}

function GetSettingStatus(name) {
    var status = '';
    $.ajax({
        type: 'GET',
        url: '/Registration/Registration/QuotaSettingName',
        data: { name: name },
        dataType: "JSON",
        async: false,
        success: function (data) {
            status = data.Status;
        }
    });
    return status;
}

function PrintConfirm(func, foc) {
    $.confirm({
        escapeKey: 'Yes',
        icon: 'fas fa-print',
        title: 'Confirmation',
        content: 'Are you sure? you want to print<br/>' +
            '<div class="form-group">' +
            '<span style="display:flex;"><label>No. of Print : </label><input type="text" id="txtprint" value="1" placeholder="" class="name form-control" style="width: 80px;height: 25px;margin: -1% 0% 0% 3%;" /></span>' +
            '</div>',
        type: 'red',
        typeAnimated: true,
        closeIcon: true,
        closeIconClass: 'fas fa-close',
        buttons: {
            Yes: {
                btnClass: 'btn-success',
                action: function () {
                    var printcount = parseInt($.trim($('#txtprint').val()));
                    for (var i = 0; i < printcount; i++) {
                        func();
                    }
                    setTimeout(function () {
                        $("#" + foc).focus();
                    }, 300);
                }
            },
            No: {
                btnClass: 'btn-danger',
                action: function () {
                    setTimeout(function () {
                        $("#" + foc).focus();
                    }, 300);
                   
                }
            }
        },
        onContentReady: function () {
            var btn = $('.jconfirm-buttons ').find(':button').filter(':visible:first');
            btn.focus();
            $(document).keydown(function (e) {
                if (e.keyCode === 39) {
                    $(".btn:focus").next().focus();
                }
                if (e.keyCode === 37) {
                    $(".btn:focus").prev().focus();
                }
            });
        }
    });
}

function BillPrintConfirm(billno, func, foc, module) {

    $.confirm({
        escapeKey: 'Yes',
        icon: 'fas fa-print',
        title: 'Confirmation',
        content: 'Are you sure? you want to print...' + "<br/> " + "<b>Bill No:" + billno + "</b><br/><br/>" +
            '<div class="form-group">' +
            '<span style="display:flex;"><label>No. of Print : </label><input type="text"  id="txtprint" value="1"   placeholder="" class="name form-control" style="width: 80px;height: 25px;margin: -1% 0% 0% 3%;" /></span>' +
            '</div>',
        type: 'red',
        typeAnimated: true,
        closeIcon: true,
        closeIconClass: 'fas fa-close',
        
        buttons: {
            Yes: {
               
                btnClass: 'btn-success',
                action: function () {
                    var printcount = parseInt($.trim($('#txtprint').val()));
                    for (var i = 0; i < printcount; i++) {
                        func();
                    }
                    AuditTrailAddPrint(module);
                    setTimeout(() => { $("#" + foc).focus() }, 100);
                }
            },
            No: {
                btnClass: 'btn-danger',
                action: function () {
                    setTimeout(() => { $("#" + foc).focus() }, 100);
                }
            }
        },
        onContentReady: function () {
            setTimeout("document.getElementById('txtprint').focus()", 10);
            setTimeout("document.getElementById('txtprint').select()", 10);
            
            var btn = $('.jconfirm-buttons ').find(':button').filter(':visible:first');
            btn.focus();
            $(document).keydown(function (e) {
                if (e.keyCode === 39) {
                    $(".btn:focus").next().focus();
                }
                if (e.keyCode === 37) {
                    $(".btn:focus").prev().focus();
                }
            });
        }
    });
}

function ReturnPrintConfirm(billno, func, foc, billprint) {
    $.confirm({
        escapeKey: 'Yes',
        icon: 'fas fa-print',
        title: 'Confirmation',
        content: 'Are you sure? you want to print...' + "<br/> " + "<b>Bill No:" + billno + "</b>",
        type: 'red',
        typeAnimated: true,
        closeIcon: true,
        closeIconClass: 'fas fa-close',
        buttons: {
            Yes: {
                btnClass: 'btn-success',
                action: function () {
                    for (var i = 0; i < billprint; i++) {
                        func();
                    }
                    setTimeout(() => { $("#" + foc).focus() }, 100);
                }
            },
            No: {
                btnClass: 'btn-danger',
                action: function () {
                    setTimeout(() => { $("#" + foc).focus() }, 100);
                }
            }
        },
        onContentReady: function () {
            var btn = $('.jconfirm-buttons ').find(':button').filter(':visible:first');
            btn.focus();
            $(document).keydown(function (e) {
                if (e.keyCode === 39) {
                    $(".btn:focus").next().focus();
                }
                if (e.keyCode === 37) {
                    $(".btn:focus").prev().focus();
                }
            });
        }
    });
}

function AuditTrailAddPrint(module) {
    $.ajax({
        type: 'GET',
        url: '/Menu/AuditTrailAddPrint',
        data: { module: module },
        dataType: "JSON",
        async: false,
        success: function (data) {
        }
    });
}

function select2closeFNC(parent, child) {
    $('#' + parent).on("select2:close", function (e) {
        if ($('#' + parent).val() === "" || $('#' + parent).val() === null || $('#' + parent).val() === "0") {
            setTimeout(function () {
                $('#' + parent).focus();
            }, 100);
        }
        else {
            setTimeout(function () {
                $('#' + child).focus();
            }, 100);
        }
    });
}

function MoveRow(tableName) {
    var trows = document.getElementById(tableName).rows, t = trows.length, trow;
    trow = trows[1];
    while (--t > 1) {
        trow = trows[t];
        trow.className = 'normal';
        trow.onclick = highlightRow;
    }
    function highlightRow(gethighlight) {
        gethighlight = gethighlight === true;
        var t = trows.length, hrow;
        while (--t > -1) {
            trow = trows[t];
            if (gethighlight && trow.className === 'highlighted') { return t; }
            else if (!gethighlight && trow !== this) { trow.className = 'normal'; }
        }
        return gethighlight ? null : this.className = this.className === 'highlighted' ? 'normal' : 'highlighted';
    }
    function movehighlight(way, e) {
        e.preventDefault && e.preventDefault();
        e.returnValue = false;
        var idx = highlightRow(true), nextrow;
        if (typeof idx === 'number') {
            idx += way;
            if (idx && (nextrow = trows[idx])) { return highlightRow.apply(nextrow); }
            else if (idx) { return highlightRow.apply(trows[1]); }
            return highlightRow.apply(trows[trows.length - 1]);
        }
        return highlightRow.apply(trows[way > 0 ? 1 : trows.length - 1]);
    }
    function processkey(e) {
        e = e || event;
        switch (e.keyCode) {
            case 38: {
                return movehighlight(-1, e);
            }
            case 40: {
                return movehighlight(1, e);
            }
            default: {
                return true;
            }
        }
    }
    document.onkeydown = processkey;
}

function IsMobileValid(phone) {
    var aa = phone.replace(/[^0-9]/g, '');
    if (phone !== "") {
        if (aa.length !== 10) {
            return 1;
        }
        else {
            return 2;
        }
    }
    else {
        return 3;
    }
}

function KEYEVENTCALL(parent, child, message) {
    if (event.keyCode === 13) {
        if ($.trim($(parent).val()) === "" || $(parent).val() === null || $(parent).val() === "0") {
            toastr.error(message, "Alert");
            $(parent).select();
        }
        else {
            $(child).select();
        }
        event.preventDefault();
        return false;
    }
}

function TextKeyEventCall(parent, child, message) {
    if (event.keyCode === 13) {
        if ($.trim($(parent).val()) === "" || $.trim($(parent).val()) === null) {
            toastr.error(message, "Alert");
            $(parent).focus();
        }
        else {
            $(child).focus();
        }
    }
}

//function PopUp(data) {
//    var mywindow = window.open('', '', 'left=0,top=0,width=950,height=600,toolbar=0,scrollbars=0,status=0,addressbar=0');
//    var is_chrome = Boolean(mywindow.chrome);
//    var isPrinting = false;
//    mywindow.document.write(data);
//    mywindow.document.close(); // necessary for IE >= 10 and necessary before onload for chrome
//    if (is_chrome) {
//        mywindow.onload = function () { // wait until all resources loaded
//            isPrinting = true;
//            mywindow.focus(); // necessary for IE >= 10
//            mywindow.print();  // change window to mywindow
//            mywindow.close();// change window to mywindow
//            isPrinting = false;
//        };
//        setTimeout(function () { if (!isPrinting) { mywindow.print(); mywindow.close(); } }, 300);
//    }
//    else {
//        mywindow.document.close(); // necessary for IE >= 10
//        mywindow.focus(); // necessary for IE >= 10
//        mywindow.print();
//        mywindow.close();
//    }
//    return true;
//}

function PopUp(data) {
    var mywindow = window.open('', '', 'left=0,top=0,width=950,height=600,toolbar=0,scrollbars=0,status=0,addressbar=0');
    mywindow.document.write(data);
    setTimeout(function () { mywindow.print(); mywindow.close(); }, 300);
    return true;

}

function CheckValueSelect2(id, focusval, errormessage) {
    var value = $(id).val();
    if (value === "" || value === null || value === "0") {
        toastr.error(errormessage, "Alert");
        setTimeout(function () {
            $(id).select2('close');
            $(id).focus();
        }, 100);
    }
    else {
        setTimeout(function () {
            $(id).select2('close');
            $(focusval).focus();
        }, 100);
    }
}

function isDate(txtDate) {
    var currVal = txtDate;
    if (currVal === '')
        return false;

    var rxDatePattern = /^(\d{4})(\/|-)(\d{1,2})(\/|-)(\d{1,2})$/; //Declare Regex
    var dtArray = currVal.match(rxDatePattern); // is format OK?

    if (dtArray === null)
        return false;

    //Checks for mm/dd/yyyy format.
    dtMonth = dtArray[3];
    dtDay = dtArray[5];
    dtYear = dtArray[1];

    if (dtMonth < 1 || dtMonth > 12)
        return false;
    else if (dtDay < 1 || dtDay > 31)
        return false;
    else if ((dtMonth === 4 || dtMonth === 6 || dtMonth === 9 || dtMonth === 11) && dtDay === 31)
        return false;
    else if (dtMonth === 2) {
        var isleap = (dtYear % 4 === 0 && (dtYear % 100 !== 0 || dtYear % 400 === 0));
        if (dtDay > 29 || (dtDay === 29 && !isleap))
            return false;
    }
    return true;
}

function checknullValue(id, errormessage, typeinput, timeout) {
    if (typeinput === "textbox") {
        $(id).css("background", "red", { timeOut: timeout });
        setTimeout(function () {
            $(id).css('background', 'white').focus();
        }, 100);
        toastr.error(errormessage, "Alert", { timeOut: timeout });
        $(id).select();
    }
    else if (typeinput === "dropdown") {
        toastr.error(errormessage, "Alert", { timeOut: timeout });
        $(id).focus();
    }
}

function GetMunicipalityByDistrictId(districtid, setval) {
    $(setval).html("");
    $.ajax({
        url: '/Registration/Registration/GetMunicipalityGetById?districtid=' + districtid,
        type: "GET",
        dataType: "JSON",
        async: false,
        success: function (data) {
            var list = '';
            if (list !== 0) {
                $.each(data, function (i, item) {
                    list += '<option value="' + item.mID + '">' + item.Municipality + '</option>';
                });
            }
            else {
                list = '<option value="0">data not found</option>';
            }
            $(setval).html(list);
        }
    });
}

function ConfirmationPopUp(content, callfnc) {
    $.confirm({
        title: 'Confirmation',
        content: content,
        type: 'red',
        typeAnimated: true,
        buttons: {
            Yes: {
                text: 'Yes',
                btnClass: 'btn-red',
                action: function () {
                    callfnc();
                }
            },
            No: function () {
            }
        },
        onContentReady: function () {
            var btn = $('.jconfirm-buttons ').find(':button').filter(':visible:first');
            btn.focus();
            $(document).keydown(function (e) {
                if (e.keyCode === 39) {
                    $(".btn:focus").next().focus();
                }
                if (e.keyCode === 37) {
                    $(".btn:focus").prev().focus();
                }
            });
        }
    });
}

function ConfirmationSamplePrint(content, callfnc) {
    $.confirm({
        title: 'Confirmation',
        content: content+"<br/>" +
            '<div class="form-group">' +
            '<span style="display:flex;margin-top: 12px;"><label>No. of Print : </label><input type="text" id="txtprint" value="1" placeholder="" class="name form-control" style="width: 80px;height: 25px;margin: -1% 0% 0% 3%;" /></span>' +
            '</div>',
        type: 'red',
        typeAnimated: true,
        buttons: {
            Yes: {
                text: 'Yes',
                btnClass: 'btn-red',
                action: function () {
                    var printcount = parseInt($.trim($('#txtprint').val()));
                    for (var i = 0; i < printcount; i++) {
                        callfnc();
                    }
                }
            },
            No: function () {
            }
        },
        onContentReady: function () {
            var btn = $('.jconfirm-buttons ').find(':button').filter(':visible:first');
            btn.focus();
            $(document).keydown(function (e) {
                if (e.keyCode === 39) {
                    $(".btn:focus").next().focus();
                }
                if (e.keyCode === 37) {
                    $(".btn:focus").prev().focus();
                }
            });
        }
    });
}

$('[id^=txtprint]').keypress(NumberOnly);
$('#txtprint').keydown(function (e) {
    if (e.keyCode === 13) {
        $('.btn-success').focus();
    }
});


function brandpopupmodal(title,firstlabel,secondlabel) {
    var html = '';
    html = '<div id="medicine-modal" class="modal fade" role="dialog">';
    html += '<div class="modal-dialog AddChooseBrandDialog">';
    html += '<div id="listloading" class="ModalLoading hide">';
    html += '<div id="listloading-content">';
    html += '<div class="image-wrapper">';
    html += '<img src="~/Content/PrameshContent/loading1.gif" alt="Loading......" />';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    html += '<div class="modal-content">';
    html += '<div class="modal-header">';
    html += '<button type="button" class="close" data-dismiss="modal">&times;</button>';
    html += '<h4><i class="fas fa-plus-circle"></i> &nbsp;' + title + '</h4>';
    html += '</div>';
    html += '<div class="modal-body">';
    html += '<section class="ChooseBrandMain">';
    html += '<div class="ChooseBrandInner">';
    html += '<form>';
    html += '<div class="row">';
    html += ' <div class="col-md-6 col-xs-12">';
    html += '<div class="left">';
    html += '<label>' + firstlabel + '</label>';
    html += '<input type="text" class="form-control b-name" id="medicinebrand" autocomplete="off">';
    html += '</div>';
    html += '</div>';
    html += '<div class="col-md-6 col-xs-12">';
    html += '<div class="rightt">';
    html += '<label>' + secondlabel + '</label>';
    html += '<input type="text" class="form-control generic" id="medicinegeneric" autocomplete="off">';
    html += '</div>';
    html += '<div class="bx">';
    html += '<span style=" background: #c1d0c1;">&nbsp&nbsp&nbsp&nbsp</span>';
    html += '<span>Not Expired</span>';
    html += '<span style=" background: red;">&nbsp&nbsp&nbsp&nbsp</span>';
    html += ' <span>Near Expiry</span>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    html += '</form>';
    html += '</div>';
    html += '</section>';
    html += '<section class="ChooseBrandTable">';
    html += '<table class="table table-bordered table-striped" id="tablemedicine">';
    html += '<thead>';
    html += '<tr>';
    html += '<th>' + firstlabel+'</th>';
    html += '<th>' + secondlabel+'</th>';
    html += '<th>Qty</th>';
    html += '<th>Rate</th>';
    html += '</tr>';
    html += '</thead>';
    html += '<tbody class="tbodymedicine"></tbody>';
    html += '</table>';
    html += '<div id="tfootmedicine"></div>';
    html += '</section>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
    html += '</div>';
}

function MessageShow(code, message) {
    code === "Success" ? toastr.success(message, "Success") : (code === "Error") ? toastr.error(message, "Alert") : (code === "Info") ? toastr.info(message, "Info") : toastr.warning(message, "Warning");
}

function CallAjax(method, url, datatype, dataparam,callfunction) {
    $.ajax({
        type: method,
        url: url,
        dataType: datatype,
        async: false,
        data: dataparam,
        success: function (data) {
            MessageShow(data.code, data.message);
            callfunction();
        },
        error: function () {
            toastr.error("Server Error", "ALert");
        }
    });
}

