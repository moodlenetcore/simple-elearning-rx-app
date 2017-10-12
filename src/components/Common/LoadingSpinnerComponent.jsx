/* eslint-disable react/self-closing-comp */
import React, { PropTypes } from 'react';

function LoadingSpinnerComponent({ type, visible, color, size, text, center, topPx, leftPercent }) {
  const styles = {
    loadingStyle: {
      width: `${size}px`,
      height: `${size}px`,
      margin: '5px',
      position: 'relative',
      float: 'left',
      top: `${topPx}px`,
    },
    centerStyle: {
      width: `${size}px`,
      height: `${size}px`,
      margin: '20px 5px',
      position: 'relative',
      left: `${leftPercent}%`,
      float: 'left',
      top: `${topPx}px`,
    },
  };

  const loadingBarsRotates = [0, 45, 90, 135, 180, 225, 270, 315];
  const loadingBarsDelays = [0.39, 0.52, 0.65, 0.78, 0.91, 1.04, 1.17, 1.3];

  const sizeVal = size || 24;
  const barHeight = Math.round(type === 'shortBars' ? (sizeVal / 12) + 3 : sizeVal / 3.5);
  const top = Math.round(size / 3);
  const left = Math.round((size / 3) + (barHeight / 2));
  const rotateVal = Math.round((size - barHeight) / 2);

  for (let inc = 0; inc < 8; inc += 1) {
    styles[`loadingBar${inc}Style`] =
    {
      width: '3px',
      height: `${barHeight}px`,
      background: color,
      borderRadius: '30%',
      position: 'absolute',
      top: `${top}px`,
      left: `${left}px`,
      opacity: '0.05',
      animation: 'fadeit 1.1s linear infinite',
      WebkitAnimation: 'fadeit 1.1s linear infinite',
      WebkitTransform: `rotate(${loadingBarsRotates[inc]}deg) translate(0, -${rotateVal}px)`,
      transform: `rotate(${loadingBarsRotates[inc]}deg) translate(0, -${rotateVal}px)`,
      WebkitAnimationDelay: `${loadingBarsDelays[inc]}s`,
      AnimationDelay: `${loadingBarsDelays[inc]}s`,
    };
  }

  const loadingTextStyle = {
    height: `${size}px`,
    lineHeight: `${size}px`,
    float: 'left',
    color,
    display: 'inline-block',
    margin: '5px',
  };

  let visibilityStyle = {};

  if (!visible) {
    visibilityStyle = { display: 'none' };
  }

  return (
    <div style={visibilityStyle}>
      <div style={center ? styles.centerStyle : styles.loadingStyle}>
        <div style={styles.loadingBar0Style}></div>
        <div style={styles.loadingBar1Style}></div>
        <div style={styles.loadingBar2Style}></div>
        <div style={styles.loadingBar3Style}></div>
        <div style={styles.loadingBar4Style}></div>
        <div style={styles.loadingBar5Style}></div>
        <div style={styles.loadingBar6Style}></div>
        <div style={styles.loadingBar7Style}></div>
      </div>
      <div style={loadingTextStyle}>{text}</div>
    </div>
  );
}

LoadingSpinnerComponent.propTypes = {
  type: PropTypes.oneOf(['shortBars', 'longBars']),
  visible: PropTypes.bool,
  color: PropTypes.string,
  size: PropTypes.oneOf([18, 24, 32, 64]),
  text: PropTypes.string,
  center: PropTypes.bool,
  leftPercent: PropTypes.number,
  topPx: PropTypes.number,
};

LoadingSpinnerComponent.defaultProps = {
  type: 'shortBars',
  visible: false,
  color: 'black',
  size: 18,
  text: '',
  center: false,
  leftPercent: 45,
  topPx: 0,
};

export default LoadingSpinnerComponent;
