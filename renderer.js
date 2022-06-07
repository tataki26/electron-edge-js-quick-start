const path = require('path');
var version = location.search.split('version=')[1];
var namespace = 'QuickStart.' + version.charAt(0).toUpperCase() + version.substr(1);
// if(version === 'core') version = 'coreapp';
if(version === 'core') version = '';

// const baseNetAppPath = path.join(__dirname, '/src/'+ namespace +'/bin/Debug/net'+ version +'2.0');
// const baseNetAppPath = path.join(__dirname, '/src/'+ namespace +'/bin/Debug/net'+ version +'5.0');
const baseNetAppPath = path.join(__dirname, '/src/'+ namespace + '/bin/x64/Debug/net'+version+'5.0');

process.env.EDGE_USE_CORECLR = 1;
if(version !== 'standard')
    process.env.EDGE_APP_ROOT = baseNetAppPath;

var edge = require('electron-edge-js');
const { Console } = require('console');
const { ipcRenderer } = require('electron');

var baseDll = path.join(baseNetAppPath, namespace + '.dll');

var localTypeName = namespace + '.LocalMethods';
var externalTypeName = namespace + '.ExternalMethods';
// var uniTypeName = namespace + '.UniDevice';
var uniTypeName = namespace + '.UniClass';

var getAppDomainDirectory = edge.func({
    assemblyFile: baseDll,
    typeName: localTypeName,
    methodName: 'GetAppDomainDirectory'
});

var getCurrentTime = edge.func({
    assemblyFile: baseDll,
    typeName: localTypeName,
    methodName: 'GetCurrentTime'
});

var useDynamicInput = edge.func({
    assemblyFile: baseDll,
    typeName: localTypeName,
    methodName: 'UseDynamicInput'
});

var sum5 = edge.func({
    assemblyFile: baseDll,
    typeName: localTypeName,
    methodName: 'Sum5'
});

var getPerson = edge.func({
    assemblyFile: baseDll,
    typeName: externalTypeName,
    methodName: 'GetPersonInfo'
});

var connect = edge.func({
    assemblyFile: baseDll,
    typeName: uniTypeName,
    methodName: 'Connect'
})


window.onload = function() {

    getAppDomainDirectory('', function(error, result) {
        if (error) throw error;
        document.getElementById("GetAppDomainDirectory").innerHTML = result;
    });

    getCurrentTime('', function(error, result) {
        if (error) throw error;
        document.getElementById("GetCurrentTime").innerHTML = result;
    });

    useDynamicInput('Node.Js', function(error, result) {
        if (error) throw error;
        document.getElementById("UseDynamicInput").innerHTML = result;
    });

    getPerson('', function(error, result) {
        //if (error) throw JSON.stringify(error);
        document.getElementById("GetPersonInfo").innerHTML = result;
    });

};

/*
window.handleClick = () => {
    ipcRenderer.send('handle-click');
    sum5(7, function(error, result){
        if (error) throw error;
        console.log(result);
    });
}
*/

window.handleClick = () => {
    connect(5000,function(error,result) {
        if (result == 0) ipcRenderer.send('connect-success');
        else 
        {
            ipcRenderer.send('connect-fail');
            console.log(result);
        }
    });
}
