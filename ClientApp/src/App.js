import React from 'react';
import { Route } from 'react-router';
import Layout from './components/Layout';
import FetchData from './components/FetchData';

export default () => (
  <Layout>
    <Route exact path='/fetch-data/:startDateIndex?' component={FetchData} />
  </Layout>
);
