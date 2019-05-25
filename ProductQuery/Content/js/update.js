function 常规(obj) {
    var tables = $("form#form");
    var addtr =
        '<div class="row" id="' + id + '">' +
        '<div class="form-group col-lg-12" id="' + obj + ModuleNumber(obj) + '">' +
        '<h1 class="tm-site-title mb-0">' + obj + ModuleNumber(obj) + '</h1>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="尺寸名称">尺寸名称</label>' +
        '<input name="尺寸名称' + ModuleNumber(obj) + '" class="form-control validate" type="text" >' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="直径">直径</label>' +
        '<label for="danwei">(mm)</label>' +
        '<input name="直径' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="常规长度">长度</label>' +
        '<label for="danwei">(mm)</label>' +
        '<input name="常规长度' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="高度">高度 </label>' +
        '<label for="danwei">(mm)</label>' +
        '<input name="高度' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<input name="常规" style="display:none" value="' + ModuleNumber(obj) + '" type="text">' +
        '</div>';
    $(addtr).appendTo(tables);
}

function 索普通直径(obj) {
    var tables = $("form#form");
    var addtr =
        '<div class="row" id="' + id + '">' +
        '<div class="form-group col-lg-12" id="' + obj + ModuleNumber(obj) + '">' +
        '<h1 class="tm-site-title mb-0">' + obj + ModuleNumber(obj) + '</h1>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="索普通直径">索普通直径 </label>' +
        '<label for="danwei">(mm)</label>' +
        '<input name="索普通直径' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<input name="索普通直径" style="display:none" value="' + ModuleNumber(obj) + '" type="text">' +
        '</div>';
    $(addtr).appendTo(tables);
}

function 爆速(obj) {
    var tables = $("form#form");
    var addtr =
        '<div class="row" id="' + id + '">' +
        '<div class="form-group col-lg-12" id="' + obj + ModuleNumber(obj) + '">' +
        '<h1 class="tm-site-title mb-0">' + obj + ModuleNumber(obj) + '</h1>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="爆速上限">爆速上限 </label>' +
        '<label for="danwei">(m/s)</label>' +
        '<label for="验证" style="color:red;display:none" id="bssx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<label for="验证" style="color:red;display:none" id="bssxx ' + ModuleNumber(obj) + '">*上限小于下限</label>' +
        '<input name="爆速上限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="爆速上限' + ModuleNumber(obj) + '" onblur="Valuevalidate4(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="爆速下限">爆速下限 </label>' +
        '<label for="danwei">(m/s)</label>' +
        '<label for="验证" style="color:red;display:none" id="bsxx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="爆速下限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="爆速下限' + ModuleNumber(obj) + '" onblur="Valuevalidate4(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="爆速备注">爆速备注</label>' +
        '<textarea class = "form-control validate tm-small" rows = "1" name="爆速备注' + ModuleNumber(obj) + '"></textarea>' +
        '</div>' +
        '<input name="爆速" style="display:none" value="' + ModuleNumber(obj) + '" type="text">' +
        '</div>';
    $(addtr).appendTo(tables);
}

function Valuevalidate4(number) {
    var name1 = document.getElementById("爆速上限" + number);
    var name2 = document.getElementById("爆速下限" + number);
    if (name1.value < name2.value) {
        document.getElementById("bssxx" + " " + number).style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("bssxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "") {
        document.getElementById("bssx" + " " + number).style.display = "none";
        document.getElementById("bsxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "") {
        document.getElementById("bssx" + " " + number).style.display = "none";
        document.getElementById("bsxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("bssx" + " " + number).style.display = "";
        document.getElementById("bsxx" + " " + number).style.display = "";
        Isreturn = true;
    }

}

function 接口信息(obj) {
    var tables = $("form#form");
    var addtr =
        '<div class="row" id="' + id + '">' +
        '<div class="form-group col-lg-12" id="' + obj + ModuleNumber(obj) + '">' +
        '<h1 class="tm-site-title mb-0">' + obj + ModuleNumber(obj) + '</h1>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="螺纹">螺纹 </label>' +
        '<label for="danwei">(mm)</label>' +
        '<input name="螺纹' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="螺距">螺距 </label>' +
        '<label for="danwei">(mm)</label>' +
        '<input name="螺距' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="公差">公差 </label>' +
        '<input name="公差' + ModuleNumber(obj) + '" class="form-control validate" type="text">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="接口信息长度">长度 </label>' +
        '<label for="danwei">(mm)</label>' +
        '<input name="接口信息长度' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="接口信息备注">接口信息备注</label>' +
        '<textarea class = "form-control validate tm-small" rows = "1" name="接口信息备注' + ModuleNumber(obj) + '"></textarea>' +
        '</div>' +
        '<input name="接口信息" style="display:none" value="' + ModuleNumber(obj) + '" type="text">' +
        '</div>';
    $(addtr).appendTo(tables);
}

function 直流电阻(obj) {
    var tables = $("form#form");
    var addtr =
        '<div class="row" id="' + id + '">' +
        '<div class="form-group col-lg-12" id="' + obj + ModuleNumber(obj) + '">' +
        '<h1 class="tm-site-title mb-0">' + obj + ModuleNumber(obj) + '</h1>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="桥个数">桥个数 </label>' +
        '<input name="直流电阻桥个数' + ModuleNumber(obj) + '" class="form-control validate" onkeyup="this.value=this.value.replace(' + /\D/g + ',' + "''" + ')" type="text">' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="电阻范围值上">电阻范围值上限 </label>' +
        '<label for="验证" style="color:red;display:none" id="dzfwzsx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<label for="验证" style="color:red;display:none" id="dzfwzsxx ' + ModuleNumber(obj) + '">*上限小于下限</label>' +
        '<input name="电阻范围值上' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="电阻范围值上限' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate1(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="dzfwzsxdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select zldz-' + ModuleNumber(obj) + '" name="电阻范围值上单位 ' + ModuleNumber(obj) + '" id="电阻范围值上单位 ' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate1(' + ModuleNumber(obj) + ')" onchange="Tb1(this,' + "'zldz-" + ModuleNumber(obj) + "'" + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="mΩ">mΩ</option>' +
        '<option value="Ω">Ω</option>' +
        '<option value="kΩ">kΩ</option>' +
        '<option value="MΩ">MΩ</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="电阻范围值下">电阻范围值下限 </label>' +
        '<label for="验证" style="color:red;display:none" id="dzfwzxx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="电阻范围值下' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="电阻范围值下限' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate1(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="dzfwzxxdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select zldz-' + ModuleNumber(obj) + '" name="电阻范围值下单位 ' + ModuleNumber(obj) + '" id="电阻范围值下单位 ' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate1(' + ModuleNumber(obj) + ')" onchange="Tb1(this,' + "'zldz-" + ModuleNumber(obj) + "'" + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="mΩ">mΩ</option>' +
        '<option value="Ω">Ω</option>' +
        '<option value="kΩ">kΩ</option>' +
        '<option value="MΩ">MΩ</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="电阻值">电阻值 </label>' +
        '<label for="验证" style="color:red;display:none" id="dzz ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="电阻值' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="电阻值' + ModuleNumber(obj) + '" onblur="Unitvalidate1(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="dzzdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="电阻值单位 ' + ModuleNumber(obj) + '" id="电阻值单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate1(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="mΩ">mΩ</option>' +
        '<option value="Ω">Ω</option>' +
        '<option value="kΩ">kΩ</option>' +
        '<option value="MΩ">MΩ</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="电阻公差值">电阻公差值 </label>' +
        '<label for="验证" style="color:red;display:none" id="dzgcz ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="电阻公差值' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="电阻公差值' + ModuleNumber(obj) + '" onblur="Unitvalidate2(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="dzgczdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="电阻公差值单位 ' + ModuleNumber(obj) + '" id="电阻公差值单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate2(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="mΩ">mΩ</option>' +
        '<option value="Ω">Ω</option>' +
        '<option value="kΩ">kΩ</option>' +
        '<option value="MΩ">MΩ</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="电阻小于值">电阻小于值 </label>' +
        '<label for="验证" style="color:red;display:none" id="dzxyz ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="电阻小于值' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="电阻小于值' + ModuleNumber(obj) + '" onblur="Unitvalidate3(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="dzxyzdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="电阻小于值单位 ' + ModuleNumber(obj) + '" id="电阻小于值单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate3(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="mΩ">mΩ</option>' +
        '<option value="Ω">Ω</option>' +
        '<option value="kΩ">kΩ</option>' +
        '<option value="MΩ">MΩ</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="电阻备注">电阻备注</label>' +
        '<textarea class = "form-control validate tm-small" rows = "1" name="电阻备注' + ModuleNumber(obj) + '"></textarea>' +
        '</div>' +
        '<input name="直流电阻" style="display:none" value="' + ModuleNumber(obj) + '" type="text">' +
        '</div>';
    $(addtr).appendTo(tables);
}

function UnitAndValuevalidate1(number) {
    var name1 = document.getElementById("电阻范围值上限" + number);
    var name2 = document.getElementById("电阻范围值上单位" + " " + number);
    var name3 = document.getElementById("电阻范围值下限" + number);
    var name4 = document.getElementById("电阻范围值下单位" + " " + number);
    if (name1.value < name3.value) {
        document.getElementById("dzfwzsxx" + " " + number).style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("dzfwzsxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "请选择" && name3.value == "" && name4.value == "请选择") {
        document.getElementById("dzfwzsx" + " " + number).style.display = "none";
        document.getElementById("dzfwzsxdw" + " " + number).style.display = "none";
        document.getElementById("dzfwzxx" + " " + number).style.display = "none";
        document.getElementById("dzfwzxxdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择" && name3.value != "" && name4.value != "请选择") {
        document.getElementById("dzfwzsx" + " " + number).style.display = "none";
        document.getElementById("dzfwzsxdw" + " " + number).style.display = "none";
        document.getElementById("dzfwzxx" + " " + number).style.display = "none";
        document.getElementById("dzfwzxxdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("dzfwzsx" + " " + number).style.display = "";
        document.getElementById("dzfwzsxdw" + " " + number).style.display = "";
        document.getElementById("dzfwzxx" + " " + number).style.display = "";
        document.getElementById("dzfwzxxdw" + " " + number).style.display = "";
        Isreturn = true;
    }

}

function Unitvalidate1(number) {
    var name1 = document.getElementById("电阻值" + number);
    var name2 = document.getElementById("电阻值单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("dzz" + " " + number).style.display = "none";
        document.getElementById("dzzdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("dzz" + " " + number).style.display = "none";
        document.getElementById("dzzdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("dzz" + " " + number).style.display = "";
        document.getElementById("dzzdw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate2(number) {
    var name1 = document.getElementById("电阻公差值" + number);
    var name2 = document.getElementById("电阻公差值单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("dzgcz" + " " + number).style.display = "none";
        document.getElementById("dzgczdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("dzgcz" + " " + number).style.display = "none";
        document.getElementById("dzgczdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("dzgcz" + " " + number).style.display = "";
        document.getElementById("dzgczdw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate3(number) {
    var name1 = document.getElementById("电阻小于值" + number);
    var name2 = document.getElementById("电阻小于值单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("dzxyz" + " " + number).style.display = "none";
        document.getElementById("dzxyzdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("dzxyz" + " " + number).style.display = "none";
        document.getElementById("dzxyzdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("dzxyz" + " " + number).style.display = "";
        document.getElementById("dzxyzdw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function 发火条件(obj) {
    var tables = $("form#form");
    var addtr =
        '<div class="row" id="' + id + '">' +
        '<div class="form-group col-lg-12" id="' + obj + ModuleNumber(obj) + '">' +
        '<h1 class="tm-site-title mb-0">' + obj + ModuleNumber(obj) + '</h1>' +
        '</div>' +
        '<div class="form-group col-lg-12">' +
        '<h2 class="tm-site-title mb-0">桥个数</h2>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="桥个数">桥个数</label>' +
        '<input name="桥个数' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="this.value=this.value.replace(' + /\D/g + ',' + "''" + ')">' +
        '</div>' +
        '<div class="form-group col-lg-12">' +
        '<h2 class="tm-site-title mb-0">电压发火</h2>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="发火电压">发火电压</label>' +
        '<label for="danwei">(V)</label>' +
        '<input name="发火电压' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="发火电压上限">发火电压上限</label>' +
        '<label for="danwei">(V)</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdysx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdysxx ' + ModuleNumber(obj) + '">*上限小于下限</label>' +
        '<input name="发火电压上限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="发火电压上限' + ModuleNumber(obj) + '" onblur="Valuevalidate1(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="发火电压下限">发火电压下限</label>' +
        '<label for="danwei">(V)</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdyxx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="发火电压下限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="发火电压下限' + ModuleNumber(obj) + '" onblur="Valuevalidate1(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="发火电容">发火电容</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdr ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="发火电容' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off"  id="发火电容' + ModuleNumber(obj) + '" onblur="Unitvalidate4(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdrdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="发火电容单位 ' + ModuleNumber(obj) + '"  id="发火电容单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate4(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="μf">μf</option>' +
        '<option value="pf">pf</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="电压发火备注">电压发火备注</label>' +
        '<textarea class = "form-control validate tm-small" rows = "1" name="电压发火备注' + ModuleNumber(obj) + '"></textarea>' +
        '</div>' +
        '<div class="form-group col-lg-12">' +
        '<h2 class="tm-site-title mb-0">电流发火</h2>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="发火电流">发火电流</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdl ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="发火电流' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="发火电流' + ModuleNumber(obj) + '" onblur="Unitvalidate5(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdldw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="发火电流单位 ' + ModuleNumber(obj) + '" id="发火电流单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate5(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="A">A</option>' +
        '<option value="mA">mA</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="发火电流上限">发火电流上限</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdlsx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdlsxx ' + ModuleNumber(obj) + '">*上限小于下限</label>' +
        '<input name="发火电流上限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="发火电流上限' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate2(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdlsxdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select fhdl' + ModuleNumber(obj) + '" name="发火电流上限单位 ' + ModuleNumber(obj) + '" id="发火电流上限单位 ' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate2(' + ModuleNumber(obj) + ')" onchange="Tb1(this,' + "'fhdl" + ModuleNumber(obj) + "'" + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="A">A</option>' +
        '<option value="mA">mA</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="发火电流下限">发火电流下限</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdlxx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="发火电流下限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="发火电流下限' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate2(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdlxxdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select fhdl' + ModuleNumber(obj) + '" name="发火电流下限单位 ' + ModuleNumber(obj) + '" id="发火电流下限单位 ' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate2(' + ModuleNumber(obj) + ')" onchange="Tb1(this,' + "'fhdl" + ModuleNumber(obj) + "'" + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="A">A</option>' +
        '<option value="mA">mA</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="发火电流时间">发火电流时间</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdlsj ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="发火电流时间' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="发火电流时间' + ModuleNumber(obj) + '" onblur="Unitvalidate6(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="fhdlsjdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="发火电流时间单位 ' + ModuleNumber(obj) + '" id="发火电流时间单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate6(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="ms">ms</option>' +
        '<option value="min">min</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="电流发火备注">电流发火备注</label>' +
        '<textarea class = "form-control validate tm-small" rows = "1" name="电流发火备注' + ModuleNumber(obj) + '"></textarea>' +
        '</div>' +
        '<div class="form-group col-lg-12">' +
        '<h2 class="tm-site-title mb-0">机械发火</h2>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="锤重">锤重</label>' +
        '<label for="验证" style="color:red;display:none" id="cz ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="锤重' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="锤重' + ModuleNumber(obj) + '" onblur="Unitvalidate7(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="czdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="锤重单位 ' + ModuleNumber(obj) + '" id="锤重单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate7(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="kg">kg</option>' +
        '<option value="g">g</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="落高">落高</label>' +
        '<label for="验证" style="color:red;display:none" id="lg ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="落高' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="落高' + ModuleNumber(obj) + '" onblur="Unitvalidate8(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="lgdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="落高单位 ' + ModuleNumber(obj) + '" id="落高单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate8(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="m">m</option>' +
        '<option value="cm">cm</option>' +
        '<option value="mm">mm</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="击针刺激量">击针刺激量</label>' +
        '<label for="danwei">(g•cm)</label>' +
        '<input name="击针刺激量' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="击针力上限">击针力上限</label>' +
        '<label for="danwei">(N)</label>' +
        '<label for="验证" style="color:red;display:none" id="jzlsx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<label for="验证" style="color:red;display:none" id="jzlsxx ' + ModuleNumber(obj) + '">*上限小于下限</label>' +
        '<input name="击针力上限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off"  id="击针力上限' + ModuleNumber(obj) + '" onblur="Valuevalidate2(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="击针力下限">击针力下限</label>' +
        '<label for="danwei">(N)</label>' +
        '<label for="验证" style="color:red;display:none" id="jzlxx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="击针力下限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off"  id="击针力下限' + ModuleNumber(obj) + '" onblur="Valuevalidate2(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="击针突出量上限">击针突出量上限</label>' +
        '<label for="danwei">(mm)</label>' +
        '<label for="验证" style="color:red;display:none" id="jztclsx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<label for="验证" style="color:red;display:none" id="jztclsxx ' + ModuleNumber(obj) + '">*上限小于下限</label>' +
        '<input name="击针突出量上限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off"  id="击针突出量上限' + ModuleNumber(obj) + '" onblur="Valuevalidate3(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="击针突出量下限">击针突出量下限</label>' +
        '<label for="danwei">(mm)</label>' +
        '<label for="验证" style="color:red;display:none" id="jztclxx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="击针突出量下限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off"  id="击针突出量下限' + ModuleNumber(obj) + '" onblur="Valuevalidate3(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="弹簧高度">弹簧高度</label>' +
        '<label for="danwei">(mm)</label>' +
        '<input name="弹簧高度' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="抗力">抗力</label>' +
        '<label for="danwei">(N)</label>' +
        '<input name="抗力' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="机械发火备注">机械发火备注</label>' +
        '<textarea class = "form-control validate tm-small" rows = "1" name="机械发火备注' + ModuleNumber(obj) + '"></textarea>' +
        '</div>' +
        '<div class="form-group col-lg-12">' +
        '<h2 class="tm-site-title mb-0">发火能量</h2>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="能量">能量</label>' +
        '<label for="验证" style="color:red;display:none" id="nl ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="能量' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="能量' + ModuleNumber(obj) + '" onblur="Unitvalidate9(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="nldw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="能量单位 ' + ModuleNumber(obj) + '" id="能量单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate9(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="J">J</option>' +
        '<option value="mJ">mJ</option>' +
        '</select>' +
        '</div>' +
        '<input name="发火条件" style="display:none" value="' + ModuleNumber(obj) + '" type="text">' +
        '</div>';
    $(addtr).appendTo(tables);
}

function UnitAndValuevalidate2(number) {
    var name1 = document.getElementById("发火电流上限" + number);
    var name2 = document.getElementById("发火电流上限单位" + " " + number);
    var name3 = document.getElementById("发火电流下限" + number);
    var name4 = document.getElementById("发火电流下限单位" + " " + number);
    if (name1.value < name3.value) {
        document.getElementById("fhdlsxx" + " " + number).style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("fhdlsxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "请选择" && name3.value == "" && name4.value == "请选择") {
        document.getElementById("fhdlsx" + " " + number).style.display = "none";
        document.getElementById("fhdlsxdw" + " " + number).style.display = "none";
        document.getElementById("fhdlxx" + " " + number).style.display = "none";
        document.getElementById("fhdlxxdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择" && name3.value != "" && name4.value != "请选择") {
        document.getElementById("fhdlsx" + " " + number).style.display = "none";
        document.getElementById("fhdlsxdw" + " " + number).style.display = "none";
        document.getElementById("fhdlxx" + " " + number).style.display = "none";
        document.getElementById("fhdlxxdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("fhdlsx" + " " + number).style.display = "";
        document.getElementById("fhdlsxdw" + " " + number).style.display = "";
        document.getElementById("fhdlxx" + " " + number).style.display = "";
        document.getElementById("fhdlxxdw" + " " + number).style.display = "";
        Isreturn = true;
    }

}

function Valuevalidate1(number) {
    var name1 = document.getElementById("发火电压上限" + number);
    var name2 = document.getElementById("发火电压下限" + number);
    if (name1.value < name2.value) {
        document.getElementById("fhdysxx" + " " + number).style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("fhdysxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "") {
        document.getElementById("fhdysx" + " " + number).style.display = "none";
        document.getElementById("fhdyxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "") {
        document.getElementById("fhdysx" + " " + number).style.display = "none";
        document.getElementById("fhdyxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("fhdysx" + " " + number).style.display = "";
        document.getElementById("fhdyxx" + " " + number).style.display = "";
        Isreturn = true;
    }

}

function Valuevalidate2(number) {
    var name1 = document.getElementById("击针力上限" + number);
    var name2 = document.getElementById("击针力下限" + number);
    if (name1.value < name2.value) {
        document.getElementById("jzlsxx" + " " + number).style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("jzlsxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "") {
        document.getElementById("jzlsx" + " " + number).style.display = "none";
        document.getElementById("jzlxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "") {
        document.getElementById("jzlsx" + " " + number).style.display = "none";
        document.getElementById("jzlxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("jzlsx" + " " + number).style.display = "";
        document.getElementById("jzlxx" + " " + number).style.display = "";
        Isreturn = true;
    }

}

function Valuevalidate3(number) {
    var name1 = document.getElementById("击针突出量上限" + number);
    var name2 = document.getElementById("击针突出量下限" + number);
    if (name1.value < name2.value) {
        document.getElementById("jztclsxx" + " " + number).style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("jztclsxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "") {
        document.getElementById("jztclsx" + " " + number).style.display = "none";
        document.getElementById("jztclxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "") {
        document.getElementById("jztclsx" + " " + number).style.display = "none";
        document.getElementById("jztclxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("jztclsx" + " " + number).style.display = "";
        document.getElementById("jztclxx" + " " + number).style.display = "";
        Isreturn = true;
    }

}

function Unitvalidate4(number) {
    var name1 = document.getElementById("发火电容" + number);
    var name2 = document.getElementById("发火电容单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("fhdr" + " " + number).style.display = "none";
        document.getElementById("fhdrdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("fhdr" + " " + number).style.display = "none";
        document.getElementById("fhdrdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("fhdr" + " " + number).style.display = "";
        document.getElementById("fhdrdw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate5(number) {
    var name1 = document.getElementById("发火电流" + number);
    var name2 = document.getElementById("发火电流单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("fhdl" + " " + number).style.display = "none";
        document.getElementById("fhdldw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("fhdl" + " " + number).style.display = "none";
        document.getElementById("fhdldw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("fhdl" + " " + number).style.display = "";
        document.getElementById("fhdldw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate6(number) {
    var name1 = document.getElementById("发火电流时间" + number);
    var name2 = document.getElementById("发火电流时间单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("fhdlsj" + " " + number).style.display = "none";
        document.getElementById("fhdlsjdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("fhdlsj" + " " + number).style.display = "none";
        document.getElementById("fhdlsjdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("fhdlsj" + " " + number).style.display = "";
        document.getElementById("fhdlsjdw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate9(number) {
    var name1 = document.getElementById("能量" + number);
    var name2 = document.getElementById("能量单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("nl" + " " + number).style.display = "none";
        document.getElementById("nldw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("nl" + " " + number).style.display = "none";
        document.getElementById("nldw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("nl" + " " + number).style.display = "";
        document.getElementById("nldw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate7(number) {
    var name1 = document.getElementById("锤重" + number);
    var name2 = document.getElementById("锤重单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("cz" + " " + number).style.display = "none";
        document.getElementById("czdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("cz" + " " + number).style.display = "none";
        document.getElementById("czdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("cz" + " " + number).style.display = "";
        document.getElementById("czdw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate8(number) {
    var name1 = document.getElementById("落高" + number);
    var name2 = document.getElementById("落高单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("lg" + " " + number).style.display = "none";
        document.getElementById("lgdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("lg" + " " + number).style.display = "none";
        document.getElementById("lgdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("lg" + " " + number).style.display = "";
        document.getElementById("lgdw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function 延期时间(obj) {
    var tables = $("form#form");
    var addtr =
        '<div class="row" id="' + id + '">' +
        '<div class="form-group col-lg-12" id="' + obj + ModuleNumber(obj) + '">' +
        '<h1 class="tm-site-title mb-0">' + obj + ModuleNumber(obj) + '</h1>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="温度条件">温度条件 </label>' +
        '<label for="danwei">(摄氏度) </label>' +
        '<input name="温度条件' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off">' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="延期时间上限">延期时间上限 </label>' +
        '<label for="验证" style="color:red;display:none" id="yqsjsx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<label for="验证" style="color:red;display:none" id="yqsjsxx ' + ModuleNumber(obj) + '">*上限小于下限</label>' +
        '<input name="延期时间上限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="延期时间上限' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate3(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="yqsjsxdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select yqsj' + ModuleNumber(obj) + '" name="延期时间上限单位 ' + ModuleNumber(obj) + '" id="延期时间上限单位 ' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate3(' + ModuleNumber(obj) + ')" onchange="Tb1(this,' + "'yqsj" + ModuleNumber(obj) + "'" + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="ms">ms</option>' +
        '<option value="s">s</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="延期时间下限">延期时间下限 </label>' +
        '<label for="验证" style="color:red;display:none" id="yqsjxx ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="延期时间下限' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="延期时间下限' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate3(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="yqsjxxdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select yqsj' + ModuleNumber(obj) + '" name="延期时间下限单位 ' + ModuleNumber(obj) + '" id="延期时间下限单位 ' + ModuleNumber(obj) + '" onblur="UnitAndValuevalidate3(' + ModuleNumber(obj) + ')" onchange="Tb1(this,' + "'yqsj" + ModuleNumber(obj) + "'" + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="ms">ms</option>' +
        '<option value="s">s</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-4">' +
        '<label for="延期时间值">延期时间值 </label>' +
        '<label for="验证" style="color:red;display:none" id="yqsjz ' + ModuleNumber(obj) + '">*不能为空</label>' +
        '<input name="延期时间值' + ModuleNumber(obj) + '" class="form-control validate" type="text" onkeyup="clearNoNum(this)" autocomplete="off" id="延期时间值' + ModuleNumber(obj) + '" onblur="Unitvalidate10(' + ModuleNumber(obj) + ')">' +
        '</div>' +
        '<div class="form-group col-lg-2">' +
        '<label for="danwei">单位</label>' +
        '<label for="验证" style="color:red;display:none" id="yqsjzdw ' + ModuleNumber(obj) + '">*选择</label>' +
        '<select class="custom-select" name="延期时间值单位 ' + ModuleNumber(obj) + '" id="延期时间值单位 ' + ModuleNumber(obj) + '" onblur="Unitvalidate10(' + ModuleNumber(obj) + ')">' +
        '<option value="请选择">请选择</option>' +
        '<option value="ms">ms</option>' +
        '<option value="s">s</option>' +
        '</select>' +
        '</div>' +
        '<div class="form-group col-lg-6">' +
        '<label for="延期时间备注">延期时间备注</label>' +
        '<textarea class = "form-control validate tm-small" rows = "1" name="延期时间备注' + ModuleNumber(obj) + '"></textarea>' +
        '</div>' +
        '<input name="延期时间" style="display:none" value="' + ModuleNumber(obj) + '" type="text">' +
        '</div>';
    $(addtr).appendTo(tables);
}

function UnitAndValuevalidate3(number) {
    var name1 = document.getElementById("延期时间上限" + number);
    var name2 = document.getElementById("延期时间上限单位" + " " + number);
    var name3 = document.getElementById("延期时间下限" + number);
    var name4 = document.getElementById("延期时间下限单位" + " " + number);
    if (name1.value < name3.value) {
        document.getElementById("yqsjsxx" + " " + number).style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("yqsjsxx" + " " + number).style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "请选择" && name3.value == "" && name4.value == "请选择") {
        document.getElementById("yqsjsx" + " " + number).style.display = "none";
        document.getElementById("yqsjsxdw" + " " + number).style.display = "none";
        document.getElementById("yqsjxx" + " " + number).style.display = "none";
        document.getElementById("yqsjxxdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择" && name3.value != "" && name4.value != "请选择") {
        document.getElementById("yqsjsx" + " " + number).style.display = "none";
        document.getElementById("yqsjsxdw" + " " + number).style.display = "none";
        document.getElementById("yqsjxx" + " " + number).style.display = "none";
        document.getElementById("yqsjxxdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("yqsjsx" + " " + number).style.display = "";
        document.getElementById("yqsjsxdw" + " " + number).style.display = "";
        document.getElementById("yqsjxx" + " " + number).style.display = "";
        document.getElementById("yqsjxxdw" + " " + number).style.display = "";
        Isreturn = true;
    }

}

function Unitvalidate10(number) {
    var name1 = document.getElementById("延期时间值" + number);
    var name2 = document.getElementById("延期时间值单位" + " " + number);
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("yqsjz" + " " + number).style.display = "none";
        document.getElementById("yqsjzdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("yqsjz" + " " + number).style.display = "none";
        document.getElementById("yqsjzdw" + " " + number).style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("yqsjz" + " " + number).style.display = "";
        document.getElementById("yqsjzdw" + " " + number).style.display = "";
        Isreturn = true;
    }
}

function Valuevalidate11() {
    var name1 = document.getElementById("索直径上限");
    var name2 = document.getElementById("索直径下限");
    if (name1.value < name2.value) {
        document.getElementById("szjsxx").style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("szjsxx").style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "") {
        document.getElementById("szjsx").style.display = "none";
        document.getElementById("szjxx").style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "") {
        document.getElementById("szjsx").style.display = "none";
        document.getElementById("szjxx").style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("szjsx").style.display = "";
        document.getElementById("szjxx").style.display = "";
        Isreturn = true;
    }
}

function Valuevalidate12() {
    var name1 = document.getElementById("燃烧压力上限");
    var name2 = document.getElementById("燃烧压力下限");
    if (name1.value < name2.value) {
        document.getElementById("rsylsxx").style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("rsylsxx").style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "") {
        document.getElementById("rsylsx").style.display = "none";
        document.getElementById("rsylxx").style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "") {
        document.getElementById("rsylsx").style.display = "none";
        document.getElementById("rsylxx").style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("rsylsx").style.display = "";
        document.getElementById("rsylxx").style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate11() {
    var name1 = document.getElementById("作用时间");
    var name2 = document.getElementById("作用时间单位");
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("zysj").style.display = "none";
        document.getElementById("zysjdw").style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("zysj").style.display = "none";
        document.getElementById("zysjdw").style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("zysj").style.display = "";
        document.getElementById("zysjdw").style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate12() {
    var name1 = document.getElementById("安全电流值");
    var name2 = document.getElementById("安全电流值单位");
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("aqdlz").style.display = "none";
        document.getElementById("aqdlzdw").style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("aqdlz").style.display = "none";
        document.getElementById("aqdlzdw").style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("aqdlz").style.display = "";
        document.getElementById("aqdlzdw").style.display = "";
        Isreturn = true;
    }
}

function Unitvalidate13() {
    var name1 = document.getElementById("时间值");
    var name2 = document.getElementById("时间值单位");
    if (name1.value == "" && name2.value == "请选择") {
        document.getElementById("sjz").style.display = "none";
        document.getElementById("sjzdw").style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择") {
        document.getElementById("sjz").style.display = "none";
        document.getElementById("sjzdw").style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("sjz").style.display = "";
        document.getElementById("sjzdw").style.display = "";
        Isreturn = true;
    }
}

function UnitAndValuevalidate4() {
    var name1 = document.getElementById("作用时间上限");
    var name2 = document.getElementById("作用时间上限单位");
    var name3 = document.getElementById("作用时间下限");
    var name4 = document.getElementById("作用时间下限单位");
    if (name1.value < name3.value) {
        document.getElementById("zysjsxx").style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("zysjsxx").style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "请选择" && name3.value == "" && name4.value == "请选择") {
        document.getElementById("zysjsx").style.display = "none";
        document.getElementById("zysjsxdw").style.display = "none";
        document.getElementById("zysjxx").style.display = "none";
        document.getElementById("zysjxxdw").style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择" && name3.value != "" && name4.value != "请选择") {
        document.getElementById("zysjsx").style.display = "none";
        document.getElementById("zysjsxdw").style.display = "none";
        document.getElementById("zysjxx").style.display = "none";
        document.getElementById("zysjxxdw").style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("zysjsx").style.display = "";
        document.getElementById("zysjsxdw").style.display = "";
        document.getElementById("zysjxx").style.display = "";
        document.getElementById("zysjxxdw").style.display = "";
        Isreturn = true;
    }

}

function UnitAndValuevalidate5() {
    var name1 = document.getElementById("安全电流值上限");
    var name2 = document.getElementById("安全电流值上限单位");
    var name3 = document.getElementById("安全电流值下限");
    var name4 = document.getElementById("安全电流值下限单位");
    if (name1.value < name3.value) {
        document.getElementById("aqdlzsxx").style.display = "";
        Isreturn = true;
    }
    else {
        document.getElementById("aqdlzsxx").style.display = "none";
        Isreturn = false;
    }
    if (name1.value == "" && name2.value == "请选择" && name3.value == "" && name4.value == "请选择") {
        document.getElementById("aqdlzsx").style.display = "none";
        document.getElementById("aqdlzsxdw").style.display = "none";
        document.getElementById("aqdlzxx").style.display = "none";
        document.getElementById("aqdlzxxdw").style.display = "none";
        Isreturn = false;
    }
    else if (name1.value != "" && name2.value != "请选择" && name3.value != "" && name4.value != "请选择") {
        document.getElementById("aqdlzsx").style.display = "none";
        document.getElementById("aqdlzsxdw").style.display = "none";
        document.getElementById("aqdlzxx").style.display = "none";
        document.getElementById("aqdlzxxdw").style.display = "none";
        Isreturn = false;
    }
    else {
        document.getElementById("aqdlzsx").style.display = "";
        document.getElementById("aqdlzsxdw").style.display = "";
        document.getElementById("aqdlzxx").style.display = "";
        document.getElementById("aqdlzxxdw").style.display = "";
        Isreturn = true;
    }

}

function Tb1(obj, cl) {
    $("." + cl + "").each(function () {
        $(this).val($(obj).val());
    });
}