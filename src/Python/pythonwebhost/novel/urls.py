# conding:utf-8

from django.conf.urls import url
from .views import hello

urlpatterns = [
    url('hello', hello, name='hello'),
]