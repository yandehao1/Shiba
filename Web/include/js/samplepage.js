//获取样本datagrid里面的数据
function GetSampleDgInfo() {
    //获取所有的行
    var _dg_SampleInfo = $('#dg_SampleInfo').datagrid('getRows');
}
//获取样本信息
function GetSampleInfo() {
    var strSampleInfoDiv = getSampleInfoFormData();
}
//提交样本数据到后台
function postSampleInfo(sampleinfo, dgrowdata) {
    //提交数据做验证
    $.ajax({
        type: "POST",
        url: '/Fp_Ajax/SubmitData.aspx?action=postSampleInfo',
        data: {
        },
        dataType: "json",
        success: function (response) {
        }
    });
}
//提交数据之后修改sampleDataGrid状态
function changeSampleDgState() {
}

function getSampleInfoFormData() {
    var sampleinfo = $("#SampleInfoForm").serializeArray();
    var samp;
    if (sampleinfo) {
        samp = JSON.stringify(sampleinfo);
    }
    return samp;
}