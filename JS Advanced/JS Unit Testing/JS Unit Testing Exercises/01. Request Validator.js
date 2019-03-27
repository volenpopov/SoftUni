function validateRequest(requestObj) {
    let methods = ['GET', 'POST', 'DELETE', 'CONNECT'];
    let uriPattern = /^(\w+?|(\.)+?\w+?)+$/;
    let versions = ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'];
    let msgPattern = /^((?!\<|\>|\\|\&|\'|\").)*$/;

    if (requestObj.method === undefined || !methods.includes(requestObj.method)) {
        throw new Error('Invalid request header: Invalid Method');
    }

    if (requestObj.uri === undefined || !uriPattern.test(requestObj.uri)) {
        throw new Error('Invalid request header: Invalid URI');
    }
    
    if (requestObj.version === undefined || !versions.includes(requestObj.version)) {
        throw new Error('Invalid request header: Invalid Version');
    }

    if (requestObj.message === undefined || !msgPattern.test(requestObj.message)) {
        throw new Error('Invalid request header: Invalid Message');
    }

    return requestObj;
}

console.log(validateRequest({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: 'aspdokpodwq'
  }));
  