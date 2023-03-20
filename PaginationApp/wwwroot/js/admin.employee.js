
var Employees = {
    settings: {
        ajax: false,
        fetchUrl: false,
        method: 'GET',
        browserPath: false,
    },

    params: {
        jqXHR: false,
    },

    init: function (settings) {
        this.settings = $.extend({}, this.settings, settings);
    },

    getEmployees: function (method, page) {
        if (this.params.jqXHR && this.params.jqXHR.readyState !== 4) {
            this.params.jqXHR.abort();
        }

        if (method) {
            this.settings.method = method;
        }

        var paramsBuilder = createEmployeesParamsBuilder();

        var beforePayload = { paramsBuilder };
        $(this).trigger({ type: 'before', payload: beforePayload });

        if (this.settings.method.toUpperCase() === 'GET') {
            this.setLoadWaiting(1);

            var self = this;
            var urlBuilder = createEmployeesURLBuilder(this.settings.fetchUrl);

            if (page) {
                paramsBuilder.addParameter('pageIndex', page);
            }

            this.params.jqXHR = $.ajax({
                cache: false,
                url: urlBuilder.addParameters(paramsBuilder.build()).build(),
                type: this.settings.method,
                success: function (response) {
                    $('.table-employees-wrapper').html(response);
                    $(self).trigger({ type: 'loaded' });
                },
                error: function () {
                    $(self).trigger({ type: 'error' });
                },
                complete: function () {
                    self.setLoadWaiting();
                }
            });

        } else {
            this.setLoadWaiting(1);

            if (page) {
                paramsBuilder.addParameter('pageIndex', page);
            }

            var self = this;

            this.params.jqXHR = $.ajax({
                cache: false,
                contentType: "application/json",
                url: this.settings.fetchUrl,
                type: 'POST',
                data: JSON.stringify(paramsBuilder.build()),
                success: function (response) {
                    $('.table-employees-wrapper').html(response);
                    $(self).trigger({ type: 'loaded' });
                },
                error: function () {
                    $(self).trigger({ type: 'error' });
                },
                complete: function () {
                    self.setLoadWaiting();
                }
            });
        }
    },

    setLoadWaiting: function (enable) {
        var $busyEl = $('.ajax-employees-busy');

        if (enable) {
            $busyEl.removeClass('display-none');
        } else {
            $busyEl.addClass('display-none');
        }
    }
};

function createEmployeesParamsBuilder() {
    return {
        params: {},

        addParameter: function (name, value) {
            this.params[name] = value;
            return this;
        },

        addParameters: function (params) {
            this.params = $.extend({}, this.params, params);
            return this;
        },

        build: function () {
            return this.params;
        }
    };
}

function createEmployeesURLBuilder(basePath) {
    return {
        params: {
            basePath: basePath,
            query: {}
        },

        addBasePath: function (url) {
            this.params.basePath = url;
            return this;
        },

        addParameter: function (name, value) {
            this.params.query[name] = value;
            return this;
        },

        addParameters: function (params) {
            this.params.query = $.extend({}, this.params.query, params);
            return this;
        },

        build: function () {
            var query = $.param(this.params.query);
            var url = this.params.basePath;

            return url.indexOf('?') !== -1
                ? url + '&' + query
                : url + '?' + query;
        }
    }
}