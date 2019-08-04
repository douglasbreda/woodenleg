import React, { Component } from "react";
import { FiMessageCircle } from "react-icons/fi";
import { FiUser } from "react-icons/fi";
import "./styles.css";


export default class NavBar extends Component {
  render() {
    return (
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="#">
          Wooden Leg
        </a>
        <button
          class="navbar-toggler"
          type="button"
          data-toggle="collapse"
          data-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon" />
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <a class="nav-link" href="#">
                My Ads
              </a>
            </li>
            <li class="nav-item">
              <a class="nav-link" href="#">
                Help
              </a>
            </li>
          </ul>
          <ul class="navbar-nav ml-auto nav-flex-icons">
      <li class="nav-item">
        <a class="nav-link waves-effect waves-light" href="#">
          <FiMessageCircle/> Chat
        </a>
      </li>
      <li class="nav-item">
        <a class="nav-link waves-effect waves-light" href="#">
          <FiUser/>My Account
        </a>
      </li>
      <li class="nav-item">
        <button type="button" class="btn btn-info" id="adButton">Announce</button>
      </li>
    </ul>
        </div>
      </nav>
    );
  }
}
